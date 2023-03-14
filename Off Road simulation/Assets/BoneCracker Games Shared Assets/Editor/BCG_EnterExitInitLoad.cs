//----------------------------------------------
//            Realistic Car Controller
//
// Copyright © 2014 - 2019 BoneCracker Games
// http://www.bonecrackergames.com
// Buğra Özdoğanlar
//
//----------------------------------------------

using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;

public class BCG_EnterExitInitLoad : MonoBehaviour {

	[InitializeOnLoad]
	public class InitOnLoad {

		static InitOnLoad(){
			
			SetEnabled("BCG_ENTEREXIT", true);

			if(!EditorPrefs.HasKey("BCG" + "0.1" + "Installed")){
				
				EditorPrefs.SetInt("BCG" + "0.1" + "Installed", 1);
				Selection.activeObject = BCG_EnterExitSettings.Instance;

			}

		}

	}

	private static BuildTargetGroup[] buildTargetGroups = new BuildTargetGroup[]
	{

		BuildTargetGroup.Standalone,
		BuildTargetGroup.Android,
		BuildTargetGroup.iOS,
		BuildTargetGroup.WebGL,
		BuildTargetGroup.Facebook,
		BuildTargetGroup.XboxOne,
		BuildTargetGroup.PS4,
		BuildTargetGroup.tvOS,
		BuildTargetGroup.Switch,
		BuildTargetGroup.WSA

	};

	private static void SetEnabled(string defineName, bool enable)
	{
		//Debug.Log("setting "+defineName+" to "+enable);
		foreach (var group in buildTargetGroups)
		{
			var defines = GetDefinesList(group);
			if (enable)
			{
				if (defines.Contains(defineName))
				{
					return;
				}
				defines.Add(defineName);
			}
			else
			{
				if (!defines.Contains(defineName))
				{
					return;
				}
				while (defines.Contains(defineName))
				{
					defines.Remove(defineName);
				}
			}
			string definesString = string.Join(";", defines.ToArray());
			PlayerSettings.SetScriptingDefineSymbolsForGroup(group, definesString);
		}
	}

	private static List<string> GetDefinesList(BuildTargetGroup group)
	{
		return new List<string>(PlayerSettings.GetScriptingDefineSymbolsForGroup(group).Split(';'));
	}

}
