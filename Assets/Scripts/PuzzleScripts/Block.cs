﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

  public event System.Action<Block> OnBlockPressed;
  public event System.Action OnFinishedMoving;
  public Vector2Int coord;
  public Vector2Int startingCoordinate;

  public void init(Vector2Int startingCoordinate, Texture2D image) {
    this.startingCoordinate = startingCoordinate;
    this.coord = startingCoordinate;
    GetComponent<MeshRenderer>().material = Resources.Load<Material>("Block");
    GetComponent<MeshRenderer>().material.mainTexture = image;
  }

  public void MoveToPosition(Vector2 target, float duration) {
    StartCoroutine(AnimateMove(target, duration));
  }

  void OnMouseDown() {
    if(OnBlockPressed != null) {
      OnBlockPressed(this);
    }
  }

  IEnumerator AnimateMove(Vector2 target, float duration) {
    Vector2 initalPosition = transform.position;
		float percent = .0f;
    		
    while(percent < 1) {
			percent += Time.deltaTime / duration;
			transform.position = Vector2.Lerp(initalPosition, target, percent);
			yield return null;
		}

		if(OnFinishedMoving != null) {
			OnFinishedMoving();
		}
  }

  public bool isAtStartingCoordinate() {
    return coord == startingCoordinate;
  }
}
