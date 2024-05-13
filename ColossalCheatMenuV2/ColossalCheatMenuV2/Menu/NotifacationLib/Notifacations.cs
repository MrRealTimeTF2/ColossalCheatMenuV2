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
    public class Notifacations : MonoBehaviour 
    {
        int NotificationDecayTime = 150;
        int NotificationDecayTimeCounter = 0;
        public static int NoticationThreshold = 5;
        string[] Notifilines;
        string newtext;
        public static string PreviousNotifi;

        public static GameObject NotiHub;
        public static Text NotiHubText;

        public static void SpawnNoti() => (NotiHub, NotiHubText) = GUICreator.CreateTextGUI("", "NotiHub", new Vector3(-2f, 0.85f, 3.6f), Camera.main.transform, TextAnchor.UpperLeft);

        private void FixedUpdate() {
            if(PluginConfig.Notifications && Menu.agreement) 
            {
                if (NotiHubText.text != null) 
                {
                    NotificationDecayTimeCounter++;
                    if (NotificationDecayTimeCounter > NotificationDecayTime) 
                    {
                        Notifilines = null;
                        newtext = "";
                        NotificationDecayTimeCounter = 0;
                        Notifilines = NotiHubText.text.Split(Environment.NewLine.ToCharArray()).Skip(1).ToArray();
                        foreach (string Line in Notifilines) {
                            if (Line != "") {
                                newtext = newtext + Line + "\n";
                            }
                        }

                        NotiHubText.text = newtext;
                    }
                } 
                else 
                {
                    if(NotificationDecayTimeCounter != null)
                        NotificationDecayTimeCounter = 0;
                }
            }
            else if(NotiHubText != null)
                NotiHubText.text = "";
        }

        public static void SendNotification(string NotificationText) {
            if (PluginConfig.Notifications) 
            {
                if (!NotificationText.Contains(Environment.NewLine)) { NotificationText = NotificationText + Environment.NewLine; }
                NotiHubText.text = NotiHubText.text + NotificationText;
                PreviousNotifi = NotificationText;
            }
        }
        public static void ClearPastNotifications(int amount) {
            string[] Notifilines = null;
            string newtext = "";
            Notifilines = NotiHubText.text.Split(Environment.NewLine.ToCharArray()).Skip(amount).ToArray();
            foreach (string Line in Notifilines) 
            {
                if (Line != "")
                    newtext = newtext + Line + "\n";

            }

            NotiHubText.text = newtext;
        }
    }
}
