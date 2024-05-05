﻿using Colossal.Menu;
using Colossal.Patches;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR;
using static Colossal.Plugin;

namespace Colossal.Mods
{
    public class TagAll : MonoBehaviour
    {
        private LineRenderer radiusLine;
        private Material lineMaterial;
        private GameObject[] objectsToDestroy;
        public void Update()
        {
            if (PluginConfig.tagall)
            {
                //switch (PluginConfig.BeamColour)
                //{
                //    case 0:
                //        lineMaterial.color = new Color(0.6f, 0f, 0.8f, 0.5f);
                //        break;
                //    case 1:
                //        lineMaterial.color = new Color(1f, 0f, 0f, 0.5f);
                //        break;
                //    case 2:
                //        lineMaterial.color = new Color(1f, 1f, 0f, 0.5f);
                //        break;
                //    case 3:
                //        lineMaterial.color = new Color(0f, 1f, 0f, 0.5f);
                //        break;
                //    case 4:
                //        lineMaterial.color = new Color(0f, 0f, 1f, 0.5f);
                //        break;
                //}

                if (PhotonNetwork.InRoom)
                {
                    GorillaTagger.Instance.tagCooldown = 0;
                    GorillaLocomotion.Player.Instance.teleportThresholdNoVel = int.MaxValue;
                    if (GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.ToLower().Contains("fected"))
                    {
                        foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                        {
                            if (!vrrig.mainSkin.material.name.ToLower().Contains("fected"))
                            {
                                if (DisableRig.disablerig)
                                    DisableRig.disablerig = false;

                                GorillaTagger.Instance.offlineVRRig.rightHandTransform.position = vrrig.transform.position;
                                GorillaTagger.Instance.offlineVRRig.transform.position = vrrig.transform.position + new Vector3(0f, -2.5f, 0f);

                                if (PluginConfig.CSVisuals)
                                {
                                    if (radiusLine == null)
                                    {
                                        lineMaterial = new Material(Shader.Find("Sprites/Default"));

                                        GameObject lineObject = new GameObject("RadiusLine");
                                        lineObject.transform.parent = vrrig.transform;
                                        radiusLine = lineObject.AddComponent<LineRenderer>();
                                        radiusLine.positionCount = 2;
                                        radiusLine.startWidth = 0.05f;
                                        radiusLine.endWidth = 0.05f;
                                        radiusLine.material = lineMaterial;
                                    }
                                    GorillaLocomotion.Player.Instance.rightControllerTransform.position = vrrig.transform.position;
                                    radiusLine.SetPosition(0, vrrig.transform.position);
                                    radiusLine.SetPosition(1, GorillaTagger.Instance.transform.position);
                                    if (radiusLine.GetPosition(0) == null)
                                    {
                                        if (radiusLine != null)
                                        {
                                            Destroy(radiusLine);
                                            radiusLine = null;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                        {
                            if (vrrig.mainSkin.material.name.ToLower().Contains("fected"))
                            {
                                if (DisableRig.disablerig)
                                    DisableRig.disablerig = false;

                                GorillaTagger.Instance.offlineVRRig.transform.position = vrrig.rightHandTransform.position;
                            }
                        }
                    }
                }
            }
            else
            {
                if (!DisableRig.disablerig)
                    DisableRig.disablerig = true;

                if (radiusLine != null)
                {
                    Destroy(radiusLine.gameObject);
                    radiusLine = null;
                }

                Destroy(holder.GetComponent<TagAll>());
            }
        }
    }
}