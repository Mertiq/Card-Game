using UnityEngine;


[ExecuteInEditMode]
public class BetterCardRotation : MonoBehaviour {

    
    public RectTransform CardFront;
    public RectTransform CardBack;
    public Transform targetFacePoint;
    public Collider col;

    private bool showingBack = false;

	
	void Update () 
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(origin: Camera.main.transform.position, 
                                  direction: (-Camera.main.transform.position + targetFacePoint.position).normalized, 
            maxDistance: (-Camera.main.transform.position + targetFacePoint.position).magnitude) ;
        bool passedThroughColliderOnCard = false;
        foreach (RaycastHit h in hits)
        {
            if (h.collider == col)
                passedThroughColliderOnCard = true;
        }

        if (passedThroughColliderOnCard!= showingBack)
        {
            showingBack = passedThroughColliderOnCard;
            if (showingBack)
            {
                CardFront.gameObject.SetActive(false);
                CardBack.gameObject.SetActive(true);
            }
            else
            {
                CardFront.gameObject.SetActive(true);
                CardBack.gameObject.SetActive(false);
            }

        }

	}
}
