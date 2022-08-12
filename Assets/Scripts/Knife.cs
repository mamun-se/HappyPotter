using UnityEngine ;
using DG.Tweening;

public class Knife : MonoBehaviour {
   [SerializeField] private float movementSpeed ;
   [SerializeField] private float hitDamage ;
   [SerializeField] private WoodRotator wood ;

   [SerializeField] private ParticleSystem woodFx ;

   private ParticleSystem.EmissionModule woodFxEmission ;

   private Rigidbody knifeRb ;
   [SerializeField] private Vector3 movementVector;
   private float maxdistanceX = 3.0f;
   private bool isMoving = false ;

   private void Start () {
      knifeRb = GetComponent<Rigidbody> () ;
      woodFxEmission = woodFx.emission ;
      woodFxEmission.enabled = false ;
   }

   private void Update () {
      isMoving = Input.GetMouseButton (0);
      GameManager.managerInstance.isPlaying = isMoving;
      if (isMoving && !GameManager.managerInstance.isFirstRoundCompleted)
         movementVector = new Vector3 (Input.GetAxis ("Mouse X"), Input.GetAxis ("Mouse Y"), 0f) * movementSpeed * Time.deltaTime;
   }

   private void FixedUpdate () {
      if (isMoving && !GameManager.managerInstance.isFirstRoundCompleted)
      {
         // knifeRb.position += movementVector;
          knifeRb.MovePosition(knifeRb.position + movementVector);
          if (knifeRb.position.x > maxdistanceX)
          {
            knifeRb.position = new Vector3(maxdistanceX, knifeRb.position.y,knifeRb.position.z);
          }
          else if (knifeRb.position.x < -maxdistanceX)
          {
            knifeRb.position = new Vector3(-maxdistanceX, knifeRb.position.y,knifeRb.position.z);
          }
      }
   }

   private void OnCollisionExit (Collision collision) {
      woodFxEmission.enabled = false ;
   }

   private void OnCollisionStay (Collision collision) {
      Coll coll = collision.collider.GetComponent <Coll> () ;
      if (coll != null) {
         woodFxEmission.enabled = true ;
         woodFx.transform.position = collision.contacts [0].point ;
         coll.HitCollider (hitDamage) ;
         wood.Hit (coll.index, hitDamage);
         Vector3 punchPos = movementVector;
         punchPos.y = punchPos.y - 0.1f;
         this.transform.DOPunchPosition(punchPos,0.025f,2,1f);
      }
   }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "model")
        {
            other.GetComponent<ColorLerpManager>().SetBottleHitColor();
        }
    }
}
