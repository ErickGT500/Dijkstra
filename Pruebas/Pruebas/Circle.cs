/*
 * Creado por SharpDevelop.
 * Usuario: erick
 * Fecha: 06/10/2020
 * Hora: 5:56 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace Dijkstra
{
	/// <summary>
	/// Description of Circulo.
	/// </summary>
	public class Circulo
	{
		int id;
		float x_c;
		float y_c;
		float r;
		bool visitado;
		
		public Circulo(float x_c, float y_c, float r, bool visitado, int id)
		{
			this.x_c = x_c;
			this.y_c = y_c;
			this.r = r;
			this.id = id;
			this.visitado = visitado;
		}
		
		public Circulo(float x_c, float y_c, float r, bool visitado)
		{
			this.x_c = x_c;
			this.y_c = y_c;
			this.r = r;
			this.visitado = visitado;
		}
		
		public void setID(int id){
			this.id = id;
		}
		
		public int getID(){
			return this.id;
		}
			
		
		public Circulo(Circulo c)
		{
			this.id = c.id;
			this.x_c = c.x_c;
			this.y_c = c.y_c;
			this.r = c.r;
			this.visitado =c.visitado;
		}
		
		public float getx_c(){
			return x_c;
		}
		

		
		public int getId(){
			return id;
		}
		
		public override string ToString()
		{
			return string.Format("Círculo '{0}' x_cen={1}, y_cen={2} Radio={3}",id, x_c, y_c, r);
		}
				public float gety_c(){
			return y_c;
		}
		
		public float getr(){
			return r;
		}
		
		public void setVisitado(bool visitad){
			visitado=visitad;
		}
		
		public bool getVisitado(){
			return visitado;
		}

	}
	
	public class ElementoDijkstra{
		int verticeProveniente;
		float pesoAcumulado;
		bool definitivo;
	
		
		public ElementoDijkstra(int verticeProveniente, float pesoAcumulado, bool definitivo){
			this.verticeProveniente = verticeProveniente;
			this.pesoAcumulado = pesoAcumulado;
			this.definitivo = definitivo;
		}
		
		public ElementoDijkstra(ElementoDijkstra ed){
			this.verticeProveniente = ed.verticeProveniente;
			this.pesoAcumulado = ed.pesoAcumulado;
			this.definitivo = ed.definitivo;
		}
		
		public ElementoDijkstra(){
			this.verticeProveniente = 0;
			this.pesoAcumulado = 0;
			this.definitivo = false;
		}
		
		public int getverticeProveniente(){
			return verticeProveniente;
		}
		
		public float getpesoAcumulado(){
			return pesoAcumulado;
		}
		
		public bool getDefinitivo(){
			return definitivo;
		}
		
		public void setverticeProveniente(int valor){
			verticeProveniente=valor;
		}
		
		public void setpesoAcumulado(float valor){
			pesoAcumulado = valor;
		}
		
		public void setDefinitivo(bool valor){
			definitivo = valor;
		}
	}
}
