using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace pantherkitty.unity.scenedump.example {
	public class PointlessBehavior : MonoBehaviour {
		public bool isBooleanArg = true;

		public ExampleRenderableClass someClassInstance = new ExampleRenderableClass();

		public int intProperty { get; set; } = 42;
		public int intMember = 69;
		public int[][] complexIntArray;

		public String stringProperty { get; set; } = "This is a string property";
		public String stringMember = "This is a public string member";
		public String[] simpleStringArray = new String[3] { "one", "two", "three" };
		public String[,] twoDimStringArray = new String[,] { { "uno", "dos", "tres" }, { "eins", "zwei", "drei" } };

		public Transform someOtherTransform;
		public GameObject someGameObject;
		public UnityEngine.Camera ourMainCamera;

		public PointlessBehavior() {

			complexIntArray = new int[5][];
			for (int y = 0; y < 5; y++) {
				int size = (y % 3) + 2;
				complexIntArray[y] = new int[size];
				for (int x = 0; x < size; x++) {
					complexIntArray[y][x] = y * x;
				}
			}
		}

		// Start is called before the first frame update
		void Start() {

		}

		// Update is called once per frame
		void Update() {

		}
	}
}
