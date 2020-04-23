using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCompination : MonoBehaviour
{
    public GameObject Button;
    public string[] KeyIDs;
    private string[] CurrentKeys;
    List<bool> Desider = new List<bool>();
    Dictionary<string, List<bool>> BoolsForKey = new Dictionary<string, List<bool>>();
    public bool Active = false;
    public Material OffColor, OnColor;
    public string activeIDs = "";
    public List<Buttom> buttons = new List<Buttom>();

    private void Start()
    {
        SpawnButtons();
        SetBools();
    }

    private void Update()
    {
        CheckButtons();
    }

    private void CheckButtons()
    {
        foreach (Buttom B in buttons)
        {

        }
    }

    private void SpawnButtons()
    {
        Vector3 Pos = transform.position;
        Quaternion Rot = transform.rotation;

        Vector3 distX = 0.5f * transform.forward;
        Vector3 distY = 0.5f * transform.right; 

        for (int i = 0; i < 9; i++)
        {
            if (i == 0)
            {
                Pos += new Vector3(0, 0, 0);
            }
            else if (i == 1)
            {
                Pos += distX + distY
            }
            else if (i == 2)
            {
                Pos += -distX + distY;
            }
            else if (i == 3)
            {
                Pos += new Vector3(-dist, 0, -dist);
            }
            else if (i == 4)
            {
                Pos += new Vector3(dist, 0, -dist);
            }
            else if (i == 5)
            {
                Pos += new Vector3(dist, 0, 0);
            }
            else if (i == 6)
            {
                Pos += new Vector3(-dist, 0, 0);
            }
            else if (i == 7)
            {
                Pos += new Vector3(0, 0, -dist);
            }
            else if (i == 8)
            {
                Pos += new Vector3(0, 0, dist);
            }

            GameObject newB = Instantiate(Button);
            newB.transform.localPosition = Pos;
            newB.transform.rotation = Rot;
            newB.transform.parent = transform;

            Buttom B = newB.GetComponent<Buttom>();
            B.isConstant = true;
            B.OnColor = OnColor;
            B.OffColor = OffColor;
        }

        //transform.localPosition = Vector3.zero;
        int[] attemps = { };
        SetID(attemps);
    }

    private void SetID(int[] attemps)
    {
        int R = Mathf.FloorToInt(Random.Range(0, KeyIDs.Length));
        bool run = true;

        foreach (int n in attemps)
        {
            if (R == n)
            {
                run = false;
            }
        }

        if (run)
        {
            for (int i = 0; i < KeyIDs.Length; i++)
            {
                string id = KeyIDs[i];

                if (id != KeyIDs[R])
                {
                    if (CurrentKeys.Length > 0)
                    {
                        foreach (string s in CurrentKeys)
                        {
                            if (KeyIDs[R] == s)
                            {
                                attemps.SetValue(attemps.Length, R);
                                SetID(attemps);
                            }
                        }
                    }
                }
            }
        }
        else
        {
            SetID(attemps);
        }
    }

    private void SetBools()
    {
        foreach (string key in KeyIDs)
        {
            BoolsForKey.Add(key, new List<bool>());

            if (key == "A1")
            {
                Desider = new List<bool>
                {
                    true,
                    true,
                    false,
                    false,
                    true,
                    false,
                    true,
                    false,
                    true
                };

                BoolsForKey[key] = Desider;
            }
            else if (key == "A2")
            {
                Desider = new List<bool>
                {
                    true,
                    true,
                    true,
                    false,
                    true,
                    true,
                    true,
                    true,
                    true
                };

                BoolsForKey[key] = Desider;
            }
            else if (key == "A3")
            {
                Desider = new List<bool>
                {
                    true,
                    true,
                    true,
                    true,
                    false,
                    false,
                    true,
                    false,
                    false
                };

                BoolsForKey[key] = Desider;
            }
            else if (key == "A4")
            {
                Desider = new List<bool>
                {
                    true,
                    true,
                    true,
                    false,
                    true,
                    false,
                    false,
                    true,
                    false
                };

                BoolsForKey[key] = Desider;
            }
            else if (key == "A5")
            {
                Desider = new List<bool>
                {
                    true,
                    false,
                    false,
                    false,
                    true,
                    false,
                    false,
                    false,
                    true
                };

                BoolsForKey[key] = Desider;
            }

            if (key == "B1")
            {
                Desider = new List<bool>
                {
                    true,
                    true,
                    true,
                    true,
                    false,
                    false,
                    true,
                    true,
                    true
                };

                BoolsForKey[key] = Desider;
            }
            else if (key == "B2")
            {
                Desider = new List<bool>
                {
                    true,
                    false,
                    true,
                    false,
                    true,
                    false,
                    true,
                    false,
                    true
                };

                BoolsForKey[key] = Desider;
            }
            else if (key == "B3")
            {
                Desider = new List<bool>
                {
                    true,
                    false,
                    true,
                    false,
                    true,
                    true,
                    false,
                    false,
                    true
                };

                BoolsForKey[key] = Desider;
            }
            else if (key == "B4")
            {
                Desider = new List<bool>
                {
                    true,
                    false,
                    false,
                    true,
                    true,
                    false,
                    false,
                    false,
                    true
                };

                BoolsForKey[key] = Desider;
            }
            else if (key == "B5")
            {
                Desider = new List<bool>
                {
                    true,
                    false,
                    true,
                    false,
                    false,
                    false,
                    true,
                    false,
                    true
                };

                BoolsForKey[key] = Desider;
            }

            if (key == "C1")
            {
                Desider = new List<bool>
                {
                    true,
                    false,
                    true,
                    true,
                    false,
                    false,
                    true,
                    false,
                    true
                };

                BoolsForKey[key] = Desider;
            }
            else if (key == "C2")
            {
                Desider = new List<bool>
                {
                    true,
                    true,
                    true,
                    false,
                    false,
                    true,
                    false,
                    false,
                    true
                };

                BoolsForKey[key] = Desider;
            }
            else if (key == "C3")
            {
                Desider = new List<bool>
                {
                    true,
                    false,
                    true,
                    true,
                    false,
                    true,
                    true,
                    true,
                    true
                };

                BoolsForKey[key] = Desider;
            }
            else if (key == "C4")
            {
                Desider = new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    true,
                    false,
                    true,
                    false,
                    true
                };

                BoolsForKey[key] = Desider;
            }
            else if (key == "C5")
            {
                Desider = new List<bool>
                {
                    true,
                    false,
                    true,
                    false,
                    true,
                    false,
                    true,
                    false,
                    false
                };

                BoolsForKey[key] = Desider;
            }
            if (key == "D1")
            {
                Desider = new List<bool>
                {
                    true,
                    true,
                    true,
                    true,
                    true,
                    true,
                    false,
                    false,
                    false
                };

                BoolsForKey[key] = Desider;
            }
            else if (key == "D2")
            {
                Desider = new List<bool>
                {
                    true,
                    true,
                    true,
                    false,
                    false,
                    true,
                    true,
                    true,
                    true
                };

                BoolsForKey[key] = Desider;
            }
            else if (key == "D3")
            {
                Desider = new List<bool>
                {
                    false,
                    true,
                    true,
                    false,
                    true,
                    true,
                    true,
                    true,
                    true
                };

                BoolsForKey[key] = Desider;
            }
            else if (key == "D4")
            {
                Desider = new List<bool>
                {
                    false,
                    false,
                    true,
                    false,
                    false,
                    true,
                    true,
                    true,
                    true
                };

                BoolsForKey[key] = Desider;
            }
            else if (key == "D5")
            {
                Desider = new List<bool>
                {
                    true,
                    false,
                    false,
                    false,
                    true,
                    false,
                    true,
                    false,
                    true
                };

                BoolsForKey[key] = Desider;
            }
            if (key == "E1")
            {
                Desider = new List<bool>
                {
                    false,
                    false,
                    false,
                    true,
                    true,
                    false,
                    true,
                    false,
                    true
                };

                BoolsForKey[key] = Desider;
            }
            else if (key == "E2")
            {
                Desider = new List<bool>
                {
                    true,
                    true,
                    false,
                    true,
                    true,
                    false,
                    true,
                    true,
                    false
                };

                BoolsForKey[key] = Desider;
            }
            else if (key == "E3")
            {
                Desider = new List<bool>
                {
                    true,
                    false,
                    false,
                    true,
                    false,
                    false,
                    true,
                    true,
                    true
                };

                BoolsForKey[key] = Desider;
            }
            else if (key == "E4")
            {
                Desider = new List<bool>
                {
                    true,
                    true,
                    true,
                    true,
                    true,
                    true,
                    true,
                    false,
                    true
                };

                BoolsForKey[key] = Desider;
            }
            else if (key == "E5")
            {
                Desider = new List<bool>
                {
                    true,
                    false,
                    true,
                    false,
                    true,
                    false,
                    false,
                    false,
                    true
                };

                BoolsForKey[key] = Desider;
            }

            if (key == "F1")
            {
                Desider = new List<bool>
                {
                    true,
                    true,
                    false,
                    false,
                    true,
                    false,
                    false,
                    true,
                    true
                };

                BoolsForKey[key] = Desider;
            }
            else if (key == "F2")
            {
                Desider = new List<bool>
                {
                    true,
                    false,
                    false,
                    true,
                    true,
                    true,
                    false,
                    false,
                    true
                };

                BoolsForKey[key] = Desider;
            }
            else if (key == "F3")
            {
                Desider = new List<bool>
                {
                    false,
                    true,
                    false,
                    true,
                    true,
                    true,
                    true,
                    true,
                    true
                };

                BoolsForKey[key] = Desider;
            }
            else if (key == "F4")
            {
                Desider = new List<bool>
                {
                    true,
                    true,
                    true,
                    true,
                    false,
                    true,
                    true,
                    false,
                    true
                };

                BoolsForKey[key] = Desider;
            }
            else if (key == "F5")
            {
                Desider = new List<bool>
                {
                    true,
                    true,
                    true,
                    true,
                    true,
                    false,
                    true,
                    true,
                    true
                };

                BoolsForKey[key] = Desider;
            }
        }
    }
}
