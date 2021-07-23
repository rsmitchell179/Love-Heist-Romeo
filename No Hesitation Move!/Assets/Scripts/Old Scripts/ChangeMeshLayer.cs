using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMeshLayer : MonoBehaviour
{

	public Renderer mesh_rend;
	public string sort_layer;


    // Start is called before the first frame update
    void Start()
    {
        if(mesh_rend == null){
    		mesh_rend = this.GetComponent<Renderer>();
    	}

    	SetLayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLayer() {
    	if(mesh_rend == null){
    		mesh_rend = this.GetComponent<Renderer>();
    	}

    	mesh_rend.sortingLayerName = sort_layer;

    }
}
