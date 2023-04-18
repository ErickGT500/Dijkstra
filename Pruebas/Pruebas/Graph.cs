/*
 * Creado por SharpDevelop.
 * Usuario: erick
 * Fecha: 06/10/2020
 * Hora: 5:30 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Dijkstra
{
	/// <summary>
	/// Descripcion de Grafo.
	/// </summary>
		
		
		public class Grafo{
			List<Vertice> vL;
			public Grafo(List<Circulo> cL){
				vL = new List<Vertice>();
				foreach(Circulo c_i in cL){
					vL.Add(new Vertice(c_i));
				}
			
			Vertice origen;
			Vertice destino;			
			
			for(int i=0; i< vL.Count; i++){
				origen = vL[i];
				for(int j=i+1; j< vL.Count; j++){
					destino = vL[j];
					origen.addArista(origen,destino,0);
					destino.addArista(destino,origen,0);
				}
			}
			}
			
			public int getVerticeCount(){
				return vL.Count;
			}
			
			public Vertice getVerticeAt(int pos){
				return vL[pos];
			}
			
			
			
		}
	
		
		public class Vertice{
			List<Arista> aristasL;
			Circulo data;
			public Vertice(Circulo data){
				aristasL = new List<Arista>();
				this.data = new Circulo(data);
			}
			
			public Circulo getdata(){
				return data;
			}
			
			public void addArista(Vertice origen,Vertice destino,float weight){
				this.aristasL.Add(new Arista(origen,destino,weight));
			}
			
			public int getAristasContador(){
				return aristasL.Count;
			}
			public Arista getAristaAt(int j){
				return aristasL[j];
			}
			
		}
		
		public class Arista{
			Vertice origen;
			Vertice destination;
			float weight;
			public Arista(Vertice origen, Vertice destination, float weight){
				this.origen = origen;
				this.destination = destination;
				this.weight = weight;
			}
			public Vertice getDestino(){
				return destination;
			}
			
			public Vertice getOrigen(){
				return origen;
			}
			
			public void setWeight(float w){
				weight=w;
			}
			
			public float getWeight(){
				return weight;
			}
			public override string ToString()
			{
				return string.Format("[Arista Weight={0}]", weight);
			}

		}

}
