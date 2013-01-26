using UnityEngine;
using System.Collections;

public class DungeonGenerator : MonoBehaviour {
	
	public int numberOfRooms = 50;
	public GameObject floorTileObject;
	public GameObject wallTileObject;
	public int boxSize = 1;
	public int maxCoridorLength = 50;
	public int minRoomSize = 3;
	public int maxRoomSize = 7;
	
	int prevX = 0;
	int prevZ = 0;
	int curX = 0;
	int curZ = 0;
	int[,] dirArr = { { 0, 1}, { 1, 0}, { 0, -1}, { -1, 0} };
	int[,] floorArr = new int[10000,2];
	int[,] wallsArr = new int[10000,2];

	int dirX;
	int dirZ;
	int rnd;
	bool cont = false;
	int arrCount = 0;
	int prevArrCount = 0;


	
	void GenerateRoom(int startX, int startZ, int roomWidth, int roomHight, int roomDirX, int roomDirZ)
	{
		bool count = false;
		if (roomDirX == 0) roomDirX = boxSize;
		if (roomDirZ == 0) roomDirZ = boxSize;
		for (int xx = 0; xx <= roomWidth;xx++)
		{
			for (int zz = 0; zz <= roomHight;zz++)
			{
				count = false;
				for( int iii = 0; iii<= arrCount; iii++)
				{
					if (floorArr[iii,0] == startX+(xx*roomDirX) && floorArr[iii,1] == startZ+(zz*roomDirZ))
					{
						count = true;
					}
				}
				if (count) continue;
				GameObject clone;
	            clone = Instantiate(
					floorTileObject, 
					new Vector3(startX+(xx*roomDirX), 0, startZ+(zz*roomDirZ)), 
					Quaternion.identity
				) as GameObject;	
				floorArr[arrCount,0] = startX+(xx*roomDirX);
				floorArr[arrCount,1] = startZ+(zz*roomDirZ);
				arrCount++;

			}
		}
	}
	
	void GenerateDongeon()
	{
		floorArr[0,0] = 0;	
		floorArr[0,1] = 0;	


		for (int i = 1; i <= numberOfRooms; i++)
        {
			Debug.Log(prevArrCount);
			rnd = Random.Range(0,4);
			dirX = dirArr[rnd,0]*boxSize;
			dirZ = dirArr[rnd,1]*boxSize;
			rnd = Random.Range(prevArrCount,arrCount+1);
			prevX = floorArr[rnd,0];
			prevZ = floorArr[rnd,1];
			
			//prevArrCount = arrCount;
			
			for (int j = 1; j<=Random.Range(3,maxCoridorLength);j++)
			{
				cont = false;
				curX = prevX + dirX;
				curZ = prevZ + dirZ;
				for( int ii = 0; ii<= arrCount; ii++)
				{
					if (floorArr[ii,0] == curX && floorArr[ii,1] == curZ)
					{
						cont = true;
						prevArrCount = 0;//------
						break;
					}
				}

				if (cont) continue; 
				GameObject clone;
	            clone = Instantiate(
					floorTileObject, 
					new Vector3(curX, 0, curZ), 
					Quaternion.identity
				) as GameObject;	
				floorArr[arrCount,0] = curX;
				floorArr[arrCount,1] = curZ;
				arrCount++;
				
				prevArrCount = arrCount;//-------
				
				prevX = curX;
				prevZ = curZ;
			}
			if(!cont) GenerateRoom(prevX, prevZ, Random.Range(minRoomSize,maxRoomSize), Random.Range(minRoomSize,maxRoomSize+1),dirX,dirZ);
        }
		GenerateWalls(); //----------
	}
	
	void GenerateWalls()
	{
		bool wallCont = false;
		int wallCount = 0;
		
		for (int w = 0; w <= arrCount; w++)	
		{
			for (int ww = 0; ww <= 3; ww++)
			{
				wallCont = false;
				for(int www = 0; www <= arrCount; www++)
				{
					if (floorArr[w,0]+dirArr[ww,0]*boxSize == floorArr[www,0] && 
						floorArr[w,1]+dirArr[ww,1]*boxSize == floorArr[www,1])
					{
						wallCont = true;
						break;
					}
				}
				if (wallCont) continue;
				GameObject cloneWall;
	            cloneWall = Instantiate(
					wallTileObject, 
					new Vector3(floorArr[w,0]+dirArr[ww,0]*boxSize, boxSize, floorArr[w,1]+dirArr[ww,1]*boxSize), 
					Quaternion.identity
				) as GameObject;
				wallsArr[wallCount,0] = floorArr[w,0]+dirArr[ww,0]*boxSize;
				wallsArr[wallCount,1] = floorArr[w,1]+dirArr[ww,1]*boxSize;
				wallCount++;
			}
		}
	}

//	void OnGUI() 
//	{
//		if (GUI.Button (new Rect (25, 25, 150, 30), "Generate dungeon")) 
//		{
//			GenerateDongeon();
//			
//			
//		}
//	}
	void Start()
	{
		GenerateDongeon();	
	}
}
