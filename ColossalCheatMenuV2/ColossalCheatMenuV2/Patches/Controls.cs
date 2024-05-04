﻿using System;
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
    internal class Controls : MonoBehaviour
    {
        public static InputDevice leftControllerOculus;
        public static InputDevice rightControllerOculus;

        public void Update()
        {
            //oculus controllers
            if (!rightControllerOculus.isValid)
                rightControllerOculus = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
            
            if (!leftControllerOculus.isValid)
                leftControllerOculus = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        }

        public static bool LeftJoystick()
        {
            bool Value = Plugin.oculus ? leftControllerOculus.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out Value) : SteamVR_Actions.gorillaTag_LeftJoystickClick.GetState(SteamVR_Input_Sources.LeftHand);
            return Value;
        }

        public static bool RightJoystick()
        {
            bool Value = Plugin.oculus ? rightControllerOculus.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out Value) : SteamVR_Actions.gorillaTag_RightJoystickClick.GetState(SteamVR_Input_Sources.RightHand);
            return Value;
        }

        public static bool RightTrigger()
        {
            bool Value = Plugin.oculus ? rightControllerOculus.TryGetFeatureValue(CommonUsages.triggerButton, out Value) : SteamVR_Actions.gorillaTag_RightTriggerClick.GetState(SteamVR_Input_Sources.RightHand);
            return Value;
        }

        public static bool LeftTrigger()
        {
            bool Value = Plugin.oculus ? leftControllerOculus.TryGetFeatureValue(CommonUsages.triggerButton, out Value) : SteamVR_Actions.gorillaTag_LeftTriggerClick.GetState(SteamVR_Input_Sources.LeftHand);
            return Value;
        }
    }
}
