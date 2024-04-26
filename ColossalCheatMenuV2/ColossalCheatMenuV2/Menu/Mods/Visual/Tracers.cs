﻿using Colossal.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using static Colossal.Plugin;

namespace Colossal.Mods
{
    public class Tracers : MonoBehaviour
    {
        private Color espcolor;
        private Vector3 pos;
        private float size;
        public void Update()
        {
            if (PluginConfig.tracers)
            {
                switch (PluginConfig.ESPColour)
                {
                    case 0:
                        espcolor = new Color(0.6f, 0f, 0.8f, 0.4f);
                        break;
                    case 1:
                        espcolor = new Color(1f, 0f, 0f, 0.4f);
                        break;
                    case 2:
                        espcolor = new Color(1f, 1f, 0f, 0.4f);
                        break;
                    case 3:
                        espcolor = new Color(0f, 1f, 0f, 0.4f);
                        break;
                    case 4:
                        espcolor = new Color(0f, 0f, 1f, 0.4f);
                        break;
                    default:
                        espcolor = new Color(0.6f, 0f, 0.8f, 0.4f);
                        break;
                }
                switch (PluginConfig.TracerPosition)
                {
                    case 0:
                        pos = GorillaTagger.Instance.rightHandTransform.position;
                        break;
                    case 1:
                        pos = GorillaTagger.Instance.leftHandTransform.position;
                        break;
                    case 2:
                        pos = GorillaTagger.Instance.headCollider.transform.position + (Vector3.up * 0.2f);
                        break;
                    case 3:
                        pos = GorillaTagger.Instance.headCollider.transform.position + GorillaTagger.Instance.headCollider.transform.forward / 2;
                        break;
                }
                switch (PluginConfig.TracerSize)
                {
                    case 0:
                        size = 0.002f;
                        break;
                    case 1:
                        size = 0.01f;
                        break;
                    case 2:
                        size = 0.025f;
                        break;
                    case 3:
                        size = 0.05f;
                        break;
                    case 4:
                        size = 0.065f;
                        break;
                    case 5:
                        size = 0.08f;
                        break;
                    case 6:
                        size = 0.1f;
                        break;
                }

                foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                {
                    if (vrrig != GorillaTagger.Instance.offlineVRRig)
                    {
                        GameObject gameObject = new GameObject("Line");
                        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();

                        Color color;
                        if (vrrig.mainSkin.material.name.Contains("fected"))
                        {
                            color = new Color(1f, 0f, 0f, 0.4f);
                            lineRenderer.startColor = color;
                            lineRenderer.endColor = color;
                        }
                        else
                        {
                            lineRenderer.startColor = espcolor;
                            lineRenderer.endColor = espcolor;
                        }

                        lineRenderer.startWidth = size;
                        lineRenderer.endWidth = size;
                        lineRenderer.positionCount = 2;
                        lineRenderer.useWorldSpace = true;
                        lineRenderer.SetPosition(0, pos);
                        lineRenderer.SetPosition(1, vrrig.transform.position);
                        lineRenderer.material.shader = Shader.Find("GUI/Text Shader");
                        GameObject.Destroy(gameObject, Time.deltaTime);
                    }
                }
            }
            else
            {
                Destroy(holder.GetComponent<Tracers>());
            }
        }
    }
}
