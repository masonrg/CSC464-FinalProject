﻿using MeshGeneration.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshGeneration.Generators
{
	public static class MeshGenerator
	{
		public static MeshData GenerateTerrainMesh(float[,] heightMap)
		{
			int width = heightMap.GetLength(0);
			int height = heightMap.GetLength(1);

			float topLeftX = (width - 1) / -2f;
			float topLeftZ = (height - 1) / 2f;

			MeshData meshData = new MeshData(width, height);
			int vertexIndex = 0;

			for(int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					meshData.vertices[vertexIndex] = new Vector3(topLeftX + x, heightMap[x, y], topLeftZ - y);
					meshData.uvs[vertexIndex] = new Vector2(x / (float)width, y / (float)height);
					if (x < width - 1 && y < height - 1)
					{
						meshData.AddTriangle(vertexIndex, vertexIndex + width + 1, vertexIndex + width);
						meshData.AddTriangle(vertexIndex + width + 1, vertexIndex, vertexIndex + 1);
					}

					vertexIndex++;
				}
			}

			return meshData;
		}
	}
}