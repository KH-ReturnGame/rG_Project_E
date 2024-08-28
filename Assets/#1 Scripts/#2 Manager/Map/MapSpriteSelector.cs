using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSpriteSelector : MonoBehaviour {
	
	public Sprite 	spU, spD, spR, spL,
			spUD, spRL, spUR, spUL, spDR, spDL,
			spULD, spRUL, spDRU, spLDR, spUDRL;
	public bool up, down, left, right;
	public int type; // 0: normal, 1: enter
	public Color normalColor, enterColor;
	Color mainColor;
	Image _image;
	void Start () {
		_image = GetComponent<Image>();
		mainColor = normalColor;
		PickSprite();
		PickColor();
	}
	void PickSprite(){ //picks correct sprite based on the four door bools
		if (up){
			if (down){
				if (right){
					if (left){
						_image.sprite = spUDRL;
					}else{
						_image.sprite = spDRU;
					}
				}else if (left){
					_image.sprite = spULD;
				}else{
					_image.sprite = spUD;
				}
			}else{
				if (right){
					if (left){
						_image.sprite = spRUL;
					}else{
						_image.sprite = spUR;
					}
				}else if (left){
					_image.sprite = spUL;
				}else{
					_image.sprite = spU;
				}
			}
			return;
		}
		if (down){
			if (right){
				if(left){
					_image.sprite = spLDR;
				}else{
					_image.sprite = spDR;
				}
			}else if (left){
				_image.sprite = spDL;
			}else{
				_image.sprite = spD;
			}
			return;
		}
		if (right){
			if (left){
				_image.sprite = spRL;
			}else{
				_image.sprite = spR;
			}
		}else{
			_image.sprite = spL;
		}
	}

	void PickColor(){ //changes color based on what type the room is
		if (type == 0){
			mainColor = normalColor;
		}else if (type == 1){
			mainColor = enterColor;
		}
		_image.color = mainColor;
	}
}