using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


	public class CSVUtilities : MonoBehaviour {

		public static string firstCharToLower(string str) {
			if (String.IsNullOrEmpty(str) || Char.IsLower(str, 0))
				return str;

			return Char.ToLowerInvariant(str[0]) + str.Substring(1);
		}

		public static string[] stringToArr(string str) {
			string[] arr = str.Split(',');
			return arr;
		}

		public static string[] Reader(string fileName) {
			try {
				using(StreamReader sr = new StreamReader(fileName)) {
					string line = sr.ReadToEnd();
					string[] array = line.Split(';');
					return array;
				}
			}
			catch(Exception e) {
				Debug.Log("The file could not be read:");
				Debug.Log(e.Message);
				return null;
			}
		}

		public static string[][] csvTo2dArray(string str) 
		{
			using(StringReader sr = new StringReader(str)) {
				var lines = new List<string[]>();
				int Row = 0;

				while(sr.Peek() > -1) {
					string[] Line = sr.ReadLine().Split(',');
					lines.Add(Line);
					Row++;
				}

				var data = lines.ToArray();
				return data;
			}
		}
	}

