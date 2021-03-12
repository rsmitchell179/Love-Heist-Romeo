using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;
using System.IO;
using System.IO.Compression;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Serialization;  

///-----------------------------------------------------------------------------------------
///   Namespace:      BE
///   Class:          SceneSlotGame
///   Description:    process user input & display result
///   Usage :		  
///   Author:         BraveElephant inc.                    
///   Version: 		  v1.0 (2015-08-30)
///-----------------------------------------------------------------------------------------
namespace BE {

	public class SceneSlotGame : MonoBehaviour {

		public	static SceneSlotGame instance;

		public	static int 		uiState = 0; 	// popup window shows or not
		public  static BENumber	Win;			// total win number

		public 	SlotGame	Slot;           // slot game class


		[SerializeField]
		Transform[] reels;

		[SerializeField]
		Sprite image7;

		public 	Button		btnSpin;

		void Awake () {
			instance=this;
		}

		void Start () {


			UpdateUI ();

		}

		void Update () {
			
			

		}
		// user clicked spin button
		public void OnButtonSpin() {
			//Debug.Log ("OnButtonSpin");


			// start spin
			SlotReturnCode code = Slot.Spin();
			// if spin succeed
			if(SlotReturnCode.Success == code) {
				UpdateUI();

			}
		}
		// update ui text & win number
		public void UpdateUI() {
		}

		// when reel stoped
		public void OnReelStop(int value) {
		}

		// when spin completed
		public void OnSpinEnd() {

			Debug.Log("Spin End");
			int i=0;
			foreach(Transform reel in reels)
            {
                if (reel.GetChild(1).GetComponent<Image>().sprite.Equals(image7))
                {
					i++;
                }
            }
            if (i == 3)
            {
				Debug.Log("777 LUCKY!!");

            }
		}


	}

}
