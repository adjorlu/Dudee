using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldCreator : MonoBehaviour {

	public GameObject _tilePrefab;
	public static int WIDTH = 30;
	public static int HEIGHT = 20;
	private List<List<Tile>> _tiles = new List<List<Tile>>();



	public void CreateRandomWorld(){
		for(int x=0; x<WIDTH; x++){
			List<Tile> tempTiles = new List<Tile>();
			for(int y=0; y<HEIGHT; y++){
				GameObject tileObj = Instantiate(_tilePrefab, new Vector3(x,y), Quaternion.identity) as GameObject;
				tileObj.transform.parent = this.transform;
				tempTiles.Add(tileObj.GetComponent<Tile>());
			}
			_tiles.Add(tempTiles);
		}
	}
}
