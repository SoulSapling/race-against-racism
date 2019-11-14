using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SetSpriteToUse : MonoBehaviour
{
	private SpriteRenderer sRenderer;
	public Sprite spriteToUse;
	private Animator anim;
	//public AnimationClip idleClip();
	private AnimationClip[] clips;
	private AnimationCurve curve;
	private Keyframe key;	
    void Start()
    {
		anim = GetComponent<Animator>();
		clips = anim.runtimeAnimatorController.animationClips;
		sRenderer = GetComponent<SpriteRenderer>();
//		key = new Keyframe(0, spriteToUse);
//		curve = AnimationCurve.AddKey(key);
//		clips[0].SetCurve("", typeof(SpriteRenderer), "m_Sprite", curve);
    }
}
