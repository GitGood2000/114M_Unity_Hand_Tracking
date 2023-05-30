using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRSocketInteractorWithStatCheck : XRSocketInteractor
{
    private string linkId;
    public bool isEntered = false;
    private XRBaseInteractable interactable;
    void Start()
    {
        linkId = this.GetComponent<Stats>().linkId;
        this.selectEntered.AddListener(Entered);
        this.selectExited.AddListener(Exited);
    }


    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        //return base.CanSelect(interactable) && !isEntered;
        return base.CanSelect(interactable) && MatchLinkId(interactable) && !isEntered && IsParentPlaced();
    }

    public override bool CanHover(IXRHoverInteractable interactable)
    {
        
        return base.CanHover(interactable) && !isEntered && MatchLinkId((IXRSelectInteractable)interactable) && IsParentPlaced();
    }

    private bool MatchLinkId(IXRSelectInteractable interactable)
    {
        return interactable.transform.GetComponent<Stats>().linkId == linkId;
    }
    public void Entered(SelectEnterEventArgs arg0)
    {
        if (isEntered) { return; }
        isEntered = true;
        interactable = (XRBaseInteractable)arg0.interactableObject;
        GameResources.SetOk(MatchLinkId(interactable));
        GameResources.SetPlace(interactable.GetComponent<Stats>().linkId, true);
        //ChangeActivityOfChildrens(true);
    }

    public void Exited(SelectExitEventArgs arg0)
    {
        if (!isEntered) { return; }
        isEntered = false;
        interactable = (XRBaseInteractable)arg0.interactableObject;
        GameResources.SetPlace(interactable.GetComponent<Stats>().linkId, false);
        //ChangeActivityOfChildrens(false);
    }

    private void ChangeActivityOfChildrens(bool value)
    {
        Transform parent = transform.parent;
        string childrens = transform.GetComponent<Stats>().parent_id;
        for (int i = 0; i < childrens.Length; i++)
        {
            parent.Find(childrens).gameObject.SetActive(value);
        }
    }

    private bool IsParentPlaced()
    {
        string parent_id = transform.GetComponent<Stats>().parent_id;
        if (parent_id == "")
        {
            return true;
        }
        return GameResources.GetPlace(parent_id);
    }
}
