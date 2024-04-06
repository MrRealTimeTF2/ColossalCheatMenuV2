﻿using BepInEx;
using Colossal.Menu;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using static Colossal.Plugin;

namespace Colossal.Mods
{
    public class WASDFly : MonoBehaviour
    {
        public static int flyspeed;
        private float X = -1;
        public void Update()
        {
            if (PluginConfig.WASDFly)
            {
                switch (Menu.Menu.MiscSettings[0].stringsliderind)
                {
                    case 0:
                        flyspeed = 5;
                        break;
                    case 1:
                        flyspeed = 7;
                        break;
                    case 2:
                        flyspeed = 10;
                        break;
                    case 3:
                        flyspeed = 13;
                        break;
                    case 4:
                        flyspeed = 16;
                        break;
                    default:
                        flyspeed = 10;
                        break;
                }

                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
                bool key = UnityInput.Current.GetKey(KeyCode.W);
                bool key2 = UnityInput.Current.GetKey(KeyCode.A);
                bool key3 = UnityInput.Current.GetKey(KeyCode.S);
                bool key4 = UnityInput.Current.GetKey(KeyCode.D);
                bool key5 = UnityInput.Current.GetKey(KeyCode.Space);
                bool key6 = UnityInput.Current.GetKey(KeyCode.LeftControl);
                if (key)
                {
                    GorillaTagger.Instance.rigidbody.transform.position += GorillaTagger.Instance.rigidbody.transform.forward * Time.deltaTime * flyspeed;
                }
                if (key3)
                {
                    GorillaTagger.Instance.rigidbody.transform.position += GorillaTagger.Instance.rigidbody.transform.forward * Time.deltaTime * -flyspeed;
                }
                bool isPressed = Mouse.current.rightButton.isPressed;
                if (isPressed)
                {
                    Vector3 eulerAngles = GorillaTagger.Instance.rigidbody.transform.rotation.eulerAngles;
                    if (X < 0f)
                        X = eulerAngles.y;
                    eulerAngles = new Vector3(eulerAngles.x, X + (Mouse.current.position.ReadValue().x / (float)Screen.width - 5) * 360f * 1.33f, eulerAngles.z);
                    GorillaTagger.Instance.rigidbody.transform.rotation = Quaternion.Euler(eulerAngles);
                }
                else
                {
                    X = -1f;
                }
                if (key2)
                {
                    GorillaTagger.Instance.rigidbody.transform.position += GorillaTagger.Instance.rigidbody.transform.right * Time.deltaTime * -flyspeed;
                }
                if (key4)
                {
                    GorillaTagger.Instance.rigidbody.transform.position += GorillaTagger.Instance.rigidbody.transform.right * Time.deltaTime * flyspeed;
                }
                if (key5)
                {
                    GorillaTagger.Instance.rigidbody.transform.position += GorillaTagger.Instance.rigidbody.transform.up * Time.deltaTime * flyspeed;
                }
                if (key6)
                {
                    GorillaTagger.Instance.rigidbody.transform.position += GorillaTagger.Instance.rigidbody.transform.up * Time.deltaTime * -flyspeed;
                }
            }
            else
            {
                Destroy(GorillaTagger.Instance.GetComponent<WASDFly>());
            }
        }
    }
}
