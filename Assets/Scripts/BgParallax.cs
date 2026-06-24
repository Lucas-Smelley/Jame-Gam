using UnityEngine;

public class ParallaxLoopLayer : MonoBehaviour
{
    public Transform leftPiece;
    public Transform rightPiece;
    public float scrollSpeed = 2f;

    [Header("Alignment")]
    public bool alignOnStart = true;
    public float bottomAlignedY = 2.7f;

    private float pieceWidth;

    void Start()
    {
        SpriteRenderer sr = leftPiece.GetComponent<SpriteRenderer>();

        if (sr == null)
        {
            Debug.LogError("Left piece needs a SpriteRenderer.");
            return;
        }

        pieceWidth = sr.bounds.size.x;

        if (alignOnStart)
        {
            leftPiece.position = new Vector3(0f, bottomAlignedY, leftPiece.position.z);
            rightPiece.position = new Vector3(pieceWidth, bottomAlignedY, rightPiece.position.z);
        }
    }

    void Update()
    {
        Vector3 movement = Vector3.left * scrollSpeed * Time.deltaTime;

        leftPiece.position += movement;
        rightPiece.position += movement;

        if (leftPiece.position.x <= -pieceWidth)
        {
            leftPiece.position = new Vector3(
                rightPiece.position.x + pieceWidth,
                leftPiece.position.y,
                leftPiece.position.z
            );
        }

        if (rightPiece.position.x <= -pieceWidth)
        {
            rightPiece.position = new Vector3(
                leftPiece.position.x + pieceWidth,
                rightPiece.position.y,
                rightPiece.position.z
            );
        }
    }
}