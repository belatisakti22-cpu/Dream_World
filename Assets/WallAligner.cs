using UnityEngine;

[ExecuteInEditMode]
public class WallAligner : MonoBehaviour
{
    public float lebarRuangan = 10f;
    public float tinggiDinding = 5f;
    public float panjangRuangan = 10f;

    [ContextMenu("Rapikan Dinding Sekarang")]
    public void AlignWalls()
    {
        // Mencari anak objek berdasarkan nama sesuai Hierarchy
        Transform front = transform.Find("Room_Modern_Wall_Front");
        Transform back = transform.Find("Room_Modern_Wall_Back");
        Transform left = transform.Find("Room_Modern_Wall_Left");
        Transform right = transform.Find("Room_Modern_Wall_Right");

        // Atur posisi dan rotasi masing-masing dinding
        if (front) {
            front.localPosition = new Vector3(0, tinggiDinding / 2, panjangRuangan / 2);
            front.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (back) {
            back.localPosition = new Vector3(0, tinggiDinding / 2, -panjangRuangan / 2);
            back.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (left) {
            left.localPosition = new Vector3(-lebarRuangan / 2, tinggiDinding / 2, 0);
            left.localRotation = Quaternion.Euler(0, 90, 0);
        }
        if (right) {
            right.localPosition = new Vector3(lebarRuangan / 2, tinggiDinding / 2, 0);
            right.localRotation = Quaternion.Euler(0, 90, 0);
        }
        
        Debug.Log("Dinding berhasil dirapikan!");
    }
}