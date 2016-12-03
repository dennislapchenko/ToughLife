using System;
using UnityEngine;
using System.Collections;
using ToughLife;
using ToughLife.Controller;
using ToughLife.Enums;
using UnityEngine.SceneManagement;

public class ButtonBinds : AcidBehaviour
{

    private Root root;

    void Awake()
    {
    }

    public void loadSessionScene()
    {
        verifyRoot();
        root.sceneController.loadScene(GameScene.SESSION);
    }

    public override void Life(Root root)
    {
        this.root = root;
    }

    private void verifyRoot()
    {
        if (root == null)
        {
            Debug.Log("Button binds trying to find parent GameManager");
            GameManager gm = GetComponentInParent<GameManager>();
            if (gm != null)
            {
                root = gm.getRoot();
                Debug.Log("ButtonBinds acquired root from parent GO (GameManager");
            }
            else
            {
                Debug.Log("ButtonBinds could not fined parent GameManager");
            }
        }
    }
}
