﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR;
using Valve.VR;

namespace Colossal.Patches
{
    //Starry wrote this so it prob sucks!!!! kisses <3
    //When Adding More ctrl+c ctrl+v
    //In If Statements Do If(LeftJoystick())

    //I made it better!!! -Colossus
    internal class Controls : MonoBehaviour
    {
        public static bool LeftJoystick()
        {
            bool Value;

            if (Plugin.oculus)
                InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(CommonUsages.primary2DAxisClick, out Value);
            else
                Value = SteamVR_Actions.gorillaTag_LeftJoystickClick.GetState(SteamVR_Input_Sources.LeftHand);

            return Value;
        }

        public static bool RightJoystick()
        {
            bool Value;

            if (Plugin.oculus)
                InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(CommonUsages.primary2DAxisClick, out Value);
            else
                Value = SteamVR_Actions.gorillaTag_RightJoystickClick.GetState(SteamVR_Input_Sources.RightHand);

            return Value;
        }

        public static bool RightTrigger()
        {
            bool Value;

            if (Plugin.oculus)
                InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(CommonUsages.triggerButton, out Value);
            else
                Value = SteamVR_Actions.gorillaTag_RightTriggerClick.GetState(SteamVR_Input_Sources.RightHand);

            return Value;
        }

        public static bool LeftTrigger()
        {
            bool Value;

            if (Plugin.oculus)
                InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(CommonUsages.triggerButton, out Value);
            else
                Value = SteamVR_Actions.gorillaTag_LeftTriggerClick.GetState(SteamVR_Input_Sources.LeftHand);

            return Value;
        }
    }
}
