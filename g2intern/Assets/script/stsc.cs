using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace myfunc
{
    public class stsc : MonoBehaviour
    {
        public static GameObject obj_create_boxs;
        public static SE_manager se_manager;

        public static void find_create_obj(string obj_name, string path, Vector3 new_pos, Vector3 new_rota, string parent_obj)
        {
            GameObject obj = (GameObject)Resources.Load(path + obj_name);
            GameObject cre_obj = Instantiate(obj, new_pos, Quaternion.Euler(new_rota));
            if (parent_obj == "box" && obj_create_boxs != null)
            {
                cre_obj.transform.SetParent(obj_create_boxs.transform, false);
            }
            else if (parent_obj != "")
            {
                cre_obj.transform.SetParent(GameObject.Find(parent_obj).transform, false);
            }
            cre_obj.name = obj_name;
        }

        public static void playSE(int n_SE)
        {
            se_manager.do_sound(n_SE);
        }

    }
}