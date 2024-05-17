﻿using ColossalCheatMenuV2.Menu;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using static Colossal.Plugin;

namespace Colossal.Menu.ClientHub {
    public class Overlay : MonoBehaviour {
        private float deltaTime;

        public static GameObject OverlayHub;
        public static Text OverlayHubText;

        public static GameObject OverlayHubRoom;
        public static Text OverlayHubTextRoom;

        public static void SpawnOverlay()
        {
            (OverlayHub, OverlayHubText) = GUICreator.CreateTextGUI("", "OverlayHub", TextAnchor.LowerLeft, new Vector3(0, 0f, 4));
            (OverlayHubRoom, OverlayHubTextRoom) = GUICreator.CreateTextGUI("", "OverlayHubRoom", TextAnchor.LowerRight, new Vector3(0, 0f, 4));
        }

        public void Update() {
            if (PluginConfig.overlay && Menu.agreement && !PluginConfig.fullghostmode) 
            {
                deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
                float fps = 1.0f / deltaTime;

                if(PhotonNetwork.InRoom)
                    OverlayHubTextRoom.text = $"<color={Menu.MenuColourString}>RoomName: </color>{PhotonNetwork.CurrentRoom.Name}\n<color={Menu.MenuColourString}>Players: </color>{PhotonNetwork.CurrentRoom.PlayerCount}";
                else 
                {
                    if (OverlayHubTextRoom.text != null)
                        OverlayHubTextRoom.text = "";
                }
                OverlayHubText.text = $"<color={Menu.MenuColourString}>Ping: </color>{PhotonNetwork.GetPing()}\n<color={Menu.MenuColourString}>FPS: </color>{fps.ToString("F2")}";
            } 
            else 
            {
                if (OverlayHubText.text != null)
                    OverlayHubText.text = "";
                if (OverlayHubTextRoom.text != null)
                    OverlayHubTextRoom.text = "";
            }
        }
    }
}
