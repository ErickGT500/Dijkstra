/*
 * Creado por SharpDevelop.
 * Usuario: erick
 * Fecha: 06/10/2020
 * Hora: 3:55 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;


namespace Dijkstra
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{	
		bool terminadoruido=false, terminado=false, Dijk=false;
		Bitmap bmp;
		Bitmap bmpUbicacion;
		List<Circulo> cL;
		List<Arista> aL;
		ElementoDijkstra[] verdijkstra;
		Grafo grafo, grafo2;
		Vertice verticeI=null;
		Vertice VerticeF=null;

		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			cL = new List<Circulo>();
			bmp = new Bitmap(pictureBox1.Width,pictureBox1.Height);
			aL = new List<Arista>();
			grafo = new Grafo(cL);
			bmpUbicacion = new Bitmap(bmp);
			//listaKruskal = new List<Arista>();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
				
		
		public void ButtoAn1Click(object sender, EventArgs e)
		{
			openFileDialog1.ShowDialog();
			string filename = openFileDialog1.FileName;
			pictureBox1.Image = Image.FromFile(filename);
			terminado=false;
			terminadoruido=false;
			treeView1.Nodes.Clear();
			cL.Clear();
			dataGridView1.Rows.Clear();
			verticeI=null;
			VerticeF=null;
			bmp = new Bitmap(filename);
			bmpUbicacion = new Bitmap(filename);
			cL.Clear();
			Dijk=false;
			auxInicial = true;
		}
		
		int num=-1;
		
		public Circulo Find_center(int x_i,int y_i, Color c){
			if(c.R>50 || c.G>50 || c.B>50){
				Circulo cir = new Circulo(-1,-1,-1,false,-1);
				return cir;
			}
			int x_0=x_i;
			int y_0=y_i;
			int x_r;
			int r=0;
			Circulo circle;
			for(y_0=y_i;y_0<bmp.Height;y_0++){
				c = bmp.GetPixel(x_0,y_0);
				if(c.R>230)
					if(c.G>230)
						if(c.B>230)
							break;
			}
							
			y_0--;
							
			int x_izq,x_der;
							
			int y_cen= y_i+ (y_0-y_i)/2;
							
			for(x_der=x_i;x_der<bmp.Width;x_der++){
				c = bmp.GetPixel(x_der,y_cen);
				if(c.R>230)
					if(c.G>230)
						if(c.B>230)
							break;
			}
			x_der--;
							
			for(x_izq=x_i;x_izq<bmp.Width;x_izq--){
				c = bmp.GetPixel(x_izq,y_cen);
				if(c.R>230)
					if(c.G>230)
						if(c.B>230)
							break;	
			}
			x_izq++;	
							
			int x_cen = (x_der+x_izq)/2;
							
			for(x_r=x_cen;x_r<bmp.Width;x_r++){
				c = bmp.GetPixel(x_r,y_cen);
				if(c.R>230)
					if(c.G>230)
						if(c.B>230)
							break;
				r++;
			}				
							
			circle = new Circulo(x_cen,y_cen,r, false);
							
			return circle;				
		}
		
		bool Check_circle(Circulo circle){
			Color c;
			float r_y=0;
			int x_cen = (int)circle.getx_c();
			int y_cen = (int)circle.gety_c();
			
			for(int i= y_cen ;i<bmp.Height;i++){
				c = bmp.GetPixel(x_cen,i);
				if(c.R>230)
					if(c.G>230)
						if(c.B>230)
							break;	
				r_y++;
			}
			
			float radius = circle.getr();
			
			if(r_y<radius-10)
				return false;
			
			if(r_y>radius+10)
				return false;
					
			return true;
		}
		
		void Paint_Circle(Circulo circle){
			Color c;
			int x_cen = (int)circle.getx_c();
			int y_cen = (int)circle.gety_c();
			
			for(int i=x_cen;i<bmp.Width;i++){
				for(int j=y_cen;j<bmp.Height;j++){
					c = bmp.GetPixel(i,j);
					if(c.R>230)
						if(c.G>230)
							if(c.B>230)
								break;
					bmp.SetPixel(i,j,Color.LightGreen);
				}
				c = bmp.GetPixel(i,y_cen);
				if(c.R>230)
					if(c.G>230)
						if(c.B>230)
							break;	
			}
			
			for(int i=x_cen;i<bmp.Width;i++){
				for(int j=y_cen;j<bmp.Height;j--){
					c = bmp.GetPixel(i,j);
					if(c.R>230)
						if(c.G>230)
							if(c.B>230)
								break;
					bmp.SetPixel(i,j,Color.LightGreen);
				}
				c = bmp.GetPixel(i,y_cen);
				if(c.R>230)
					if(c.G>230)
						if(c.B>230)
							break;	
			}
			
			for(int i=x_cen;i<bmp.Width;i--){
				for(int j=y_cen;j<bmp.Height;j--){
					c = bmp.GetPixel(i,j);
					if(c.R>230)
						if(c.G>230)
							if(c.B>230)
								break;	
					bmp.SetPixel(i,j,Color.LightGreen);
				}
				c = bmp.GetPixel(i,y_cen);
				if(c.R>230)
					if(c.G>230)
						if(c.B>230)
							break;		
			}
			
			for(int i=x_cen;i<bmp.Width;i--){
				for(int j=y_cen;j<bmp.Height;j++){
					c = bmp.GetPixel(i,j);
					if(c.R>230)
						if(c.G>230)
							if(c.B>230)
								break;	
					bmp.SetPixel(i,j,Color.LightGreen);
				}
				c = bmp.GetPixel(i,y_cen);
				if(c.R>230)
					if(c.G>230)
						if(c.B>230)
							break;	
			}
		}	
		
		void drawCircleBlack(Circulo circle, Bitmap bitmap){
			int x_c = (int)circle.getx_c();
			int y_c = (int)circle.gety_c();
			int r = (int)circle.getr();
			
			Graphics g = Graphics.FromImage(bitmap);
			Brush gBrush = new SolidBrush(Color.Black);
			g.FillEllipse(gBrush, x_c-r, y_c-r, 2*r+4,2*r+4);
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			
			for(int y_i = 0; y_i < bmp.Height; y_i++)
				for(int x_i = 0; x_i < bmp.Width; x_i++){
					Color c=bmp.GetPixel(x_i,y_i);
					if(c.R >230)
						if(c.G >230)
							if(c.B >230)
								bmp.SetPixel(x_i,y_i,Color.White);
					}
		int id=0;
			Circulo circle;
			if(pictureBox1.Image != null){
			Color c;
			for(int y_i=0;y_i<bmp.Height;y_i++){
				for(int x_i=0;x_i<bmp.Width ;x_i++){	
				c = bmp.GetPixel(x_i,y_i);
				if(c.R<230)
					if(c.G<230)
						if(c.B<230){
							circle = Find_center(x_i,y_i,c);
							
							if(circle.getID() > -1){
							
								if(Check_circle(circle)){
									circle.setID(id);
									cL.Add(circle);
									Paint_Circle(circle);
									id++;
								}
							}
						}
				}
			}
			
			
			//MessageBox.Show(cL.Count.ToString());
			
			for(int i=0;i<cL.Count;i++){
				drawCircleBlack(cL[i], bmp);
			}
			
			
			
			
			
			bmp = CrearGrafo();
				
			pictureBox1.Image = bmp;
		}
		}
		
		
		public Bitmap CrearGrafo()
		{
			Brush brochaFuente = new SolidBrush(Color.LightSkyBlue);
			int unicode = 0;
			Bitmap bmpGrafo = new Bitmap(bmp);
			grafo = new Grafo(cL);
			dibujarGrafo(bmpGrafo, grafo);
			Graphics g = Graphics.FromImage(bmpGrafo);
			for(int z=0;z<cL.Count;z++){
				string character = cL[z].getID().ToString();
				g.DrawString(character,new Font("Console",20),brochaFuente,grafo.getVerticeAt(z).getdata().getx_c()-15,grafo.getVerticeAt(z).getdata().gety_c()-15);
				unicode++;
			}
			return bmpGrafo;
		}
		
		void dibujarGrafo(Bitmap bmp, Grafo grafo){
			Graphics g = Graphics.FromImage(bmp);
			Pen artistaPenc = new Pen(Color.GreenYellow, 3);
			Vertice origen;
			Circulo c_o;
			Circulo c_d;
			string a;
			int cont=0;
			Arista arista;
			Point p_i = new Point();
			Point p_f = new Point();
			Point p_0 = new Point();
			Point p_1 = new Point();
			for(int i=0; i< grafo.getVerticeCount(); i++){
				origen = grafo.getVerticeAt(i);
				c_o = origen.getdata();
				treeView1.BeginUpdate();
					treeView1.Nodes.Add(c_o.ToString());
				treeView1.EndUpdate();
				for(int j=0; j< origen.getAristasContador(); j++){
					c_d = origen.getAristaAt(j).getDestino().getdata();
					arista=origen.getAristaAt(j);
					p_i.X=(int)c_o.getx_c();
					p_i.Y=(int)c_o.gety_c();
					p_f.X=(int)c_d.getx_c();
					p_f.Y=(int)c_d.gety_c();
					p_0=ubicacion1(bmp,p_i,p_f);
					p_1=ubicacion2(bmp,p_i,p_f);
					dibujarArista(bmp,p_0,p_1,g,i,c_d, arista, p_i, p_f);
					pictureBox1.Image = bmp;
					pictureBox1.Refresh();
					if(!origen.getAristaAt(j).getDestino().getdata().getVisitado()){
						a = origen.getAristaAt(j).getWeight().ToString();
						
						if(a!="0"){
							Arista arist = new Arista(origen,origen.getAristaAt(j).getDestino(),origen.getAristaAt(j).getWeight());
							aL.Add(arist);
							dataGridView1.Rows.Add();
							dataGridView1.Rows[cont].Cells[0].Value = a;
							cont++;}
					}
					origen.getdata().setVisitado(true);
				}
			}
			pictureBox1.Image = bmp;
			
		}

		public void animarParticula(Point p_0,Point p_f,Bitmap bmp){
			Graphics g = Graphics.FromImage(bmp);
			Pen artistaPenc = new Pen(Color.Green, 4);
			Brush particulaBrocha = new SolidBrush(Color.DarkBlue);
			Brush GreenYellowBrocha = new SolidBrush(Color.Green);
			Brush negro = new SolidBrush(Color.Black);
			float x_0 = p_0.X;
			float y_0 = p_0.Y;
			float x_f = p_f.X;
			float y_f = p_f.Y;
			
			float x_i=0;
			float y_i;
			
			float x_ant;
			float y_ant;
			
			bool aux=false;
			
			if((x_f-x_0)==0)
				aux=true;
			
			float m = (y_f-y_0)/(x_f-x_0);
			float b = y_0-m*x_0;
			
			int inc = 1;
			
			x_ant = x_0;
			y_ant = y_0;
			if(m<1 && m>-1){
				if(x_0>x_f)
					inc=-1;
				for(x_i = x_0+inc; x_i!=x_f;x_i+=inc){
					if(aux)
						y_i=b;
					else
						y_i = m*x_i+b;
					g.FillEllipse(GreenYellowBrocha,(int)(Math.Round(x_ant))-8,(int)(Math.Round(y_ant))-8,10, 10);
					g.FillEllipse(particulaBrocha,(int)(Math.Round(x_i))-8,(int)(Math.Round(y_i))-8,10, 10);
					pictureBox1.Refresh();
					x_ant = x_i;
					y_ant = y_i;
				}
				g.FillEllipse(negro,(int)(Math.Round(x_0))-8,(int)(Math.Round(y_0))-8,10, 10);
				for(int y_in = 0; y_in < bmp.Height; y_in++)
					for(int x_in = 0; x_in < bmp.Width; x_in++){
						Color c=bmp.GetPixel(x_in,y_in);
						if(c.R==255 && c.G==192 && c.B==203)
							bmp.SetPixel(x_in,y_in,Color.Black);
			}
				g.DrawLine(artistaPenc,x_0,y_0,x_f,y_f);

			}
			else{
				if(y_0>y_f)
					inc = -1;
				for(y_i = y_0+inc; y_i != y_f; y_i+=inc){
					if(aux)
						x_i=x_0;
					else
						x_i = (y_i-b)/m;
					g.FillEllipse(GreenYellowBrocha,(int)(Math.Round(x_ant))-8,(int)(Math.Round(y_ant))-8,10, 10);
					g.FillEllipse(particulaBrocha,(int)(Math.Round(x_i))-8,(int)(Math.Round(y_i))-8,10, 10);
					x_ant = x_i;
					y_ant = y_i;
					pictureBox1.Refresh();
				}
				g.FillEllipse(negro,(int)(Math.Round(x_0))-8,(int)(Math.Round(y_0))-8,10, 10);
				for(int y_in = 0; y_in < bmp.Height; y_in++)
					for(int x_in = 0; x_in < bmp.Width; x_in++){
						Color c=bmp.GetPixel(x_in,y_in);
						if(c.R==255 && c.G==192 && c.B==203)
							bmp.SetPixel(x_in,y_in,Color.Black);
			}
				g.DrawLine(artistaPenc,x_0,y_0,x_f,y_f);
			}
			
			pictureBox1.Image = bmp;
		}
		
		public void drawLinePixelbyPixel(Point p_0, Point p_f,Bitmap bmp){
			float x_0 = p_0.X;
			float y_0 = p_0.Y;
			float x_f = p_f.X;
			float y_f = p_f.Y;
			
			float x_i;
			float y_i;
			
			bool aux=false;
			
			if((x_f-x_0)==0)
				aux=true;
			
			float m = (y_f-y_0)/(x_f-x_0);
			float b = y_0-m*x_0;
			
			int inc = 1;
			
			if(m<1 && m>-1){
				if(x_0>x_f)
					inc=-1;
				for(x_i = x_0; x_i!=x_f;x_i+=inc){
					if(aux)
						y_i=b;
					else
						y_i = m*x_i+b;
					bmp.SetPixel((int)(Math.Round(x_i)),(int)(Math.Round(y_i)),Color.Red);
				}
			}
			else{
				if(y_0>y_f)
					inc = -1;
				for(y_i = y_0; y_i != y_f; y_i+=inc){
					if(aux)
						x_i=x_0;
					else
						x_i = (y_i-b)/m;
					bmp.SetPixel((int)(Math.Round(x_i)),(int)(Math.Round(y_i)),Color.Red);
				}
			}
			pictureBox1.Image = bmp;
		}

		Bitmap dibujarArista(Bitmap bitmap,Point p_0, Point p_f, Graphics gr, int i, Circulo c_d, Arista arista, Point P_Inicial, Point P_Final)
			{
			int X0 = p_0.X;
			int Y0 = p_0.Y;
			int X1 = p_f.X;
			int Y1 = p_f.Y;
			int I = i;
			float w;
			int dx = Math.Abs(p_f.X - p_0.X), sx = p_0.X < p_f.X ? 1 : -1;
			int dy = Math.Abs(p_f.Y - p_0.Y), sy = p_0.Y < p_f.Y ? 1 : -1;
			int err = (dx > dy ? dx : -dy) / 2, e2;
			Pen artistaPenc = new Pen(Color.GreenYellow, 5);
			for(;;) {
				Color co=bmp.GetPixel(p_0.X,p_0.Y);
				if(co.R==255 && co.G==255 && co.B==255){
				}
				else
					break;				
				if (p_0.X == p_f.X && p_0.Y == p_f.Y){
					
					w=(float)cambiarPeso(P_Inicial, P_Final);
					arista.setWeight(w);
					
					gr.DrawLine(artistaPenc,X0,Y0,X1,Y1);
					treeView1.BeginUpdate();
						treeView1.Nodes[I].Nodes.Add(c_d.ToString());
					treeView1.EndUpdate();
					break;
				}
				e2 = err;
				if (e2 > -dx){ 
					err -= dy; p_0.X += sx; 
				}
				if (e2 < dy) {
					err += dx; p_0.Y += sy; 
				}
			}
			return bitmap;
			}
		
		public Point ubicacion1(Bitmap bmp,Point p_f,Point p_0){
			int dx = Math.Abs(p_f.X - p_0.X), sx = p_0.X < p_f.X ? 1 : -1;
			int dy = Math.Abs(p_f.Y - p_0.Y), sy = p_0.Y < p_f.Y ? 1 : -1;
			int err = (dx > dy ? dx : -dy) / 2, e2;
			for(;;) {
				Color co=bmp.GetPixel(p_0.X,p_0.Y);
				if(co.R==0 && co.G==0 && co.B==0 || co.R==255 && co.G==0 && co.B==255){
				}
				else
					break;				
				if (p_0.X == p_f.X && p_0.Y == p_f.Y){break;}
				e2 = err;
				if (e2 > -dx){ 
					err -= dy; p_0.X += sx; 
				}
				if (e2 < dy) {
					err += dx; p_0.Y += sy; 
				}
			}
			return p_0;
		}
		public Point ubicacion2(Bitmap bmp,Point p_0,Point p_f){
			int dx1 = Math.Abs(p_0.X - p_f.X), sx1 = p_0.X < p_f.X ? 1 : -1;
			int dy1 = Math.Abs(p_0.Y - p_f.Y), sy1 = p_0.Y < p_f.Y ? 1 : -1;
			int err1 = (dx1 > dy1 ? dx1 : -dy1) / 2, e1;
			
			for(;;) {
				Color co=bmp.GetPixel(p_0.X,p_0.Y);
				if(co.R==0 && co.G==0 && co.B==0){
				}
				else
					break;				
				if (p_0.X == p_f.X && p_0.Y == p_f.Y){break;}
				e1 = err1;
				if (e1 > -dx1){ 
					err1 -= dy1; p_0.X += sx1; 
				}
				if (e1 < dy1) {
					err1 += dx1; p_0.Y += sy1; 
				}
			}
			return p_0;
		}
		
		public double cambiarPeso(Point p_0, Point p_f){
			Double resultado = Math.Sqrt(Math.Pow(p_0.X-p_f.X,2)+Math.Pow(p_0.Y-p_f.Y,2));
			return resultado;
		}
		
		
		
		public List<List<Vertice>> inicializaCC(List<Vertice> vL){
			List<List<Vertice>> cr = new List<List<Vertice>>();
			foreach(Vertice v in vL){
				List<Vertice> l = new List<Vertice>();
				l.Add(v);
				cr.Add(l);
			}
			return cr;
		}
		
		public List<Vertice> buscaCC(List<List<Vertice>> cc, Vertice v){
			int index = 0;
			foreach(List<Vertice> verL in cc){
				if(verL.Contains(v)){
					return cc[index];
				}
				index++;
			}
			return null;
		}
		
		public void fusionaCC(List<List<Vertice>> cc, List<Vertice> c_1, List<Vertice> c_2){
			int index = 0;
			cc.Remove(c_2);
			index = cc.IndexOf(c_1);
			foreach(Vertice v in c_2){
				cc[index].Add(v);
			}
		}
		
		
		
		bool auxInicial = true;
		
		/*for(int i=0;i<grafo.getVerticeCount();i++){
				if(grafo.getVerticeAt(i).getdata().getId()==ascii && Dijk==false)
					verticeI = grafo.getVerticeAt(i);
				if(grafo.getVerticeAt(i).getdata().getId()==ascii && Dijk==true)
					VerticeF = grafo.getVerticeAt(i);
			}
			
			
			if(Dijk==false){
				Dijkstra(grafo,verticeI);
				Dijkstra2(grafo,verticeI,VerticeF);
				MessageBox.Show("nel");
			}
			textBox2.Clear();
			if(Dijk==true){
				Dijkstra(grafo,verticeI);
				Dijkstra2(grafo,verticeI,VerticeF);
				Vertice valor = VerticeF;
				verticeI = valor;
			}*/
		
		void AlgoritmoDijkstraClick(object sender, EventArgs e)
		{
			
			for(int y_in = 0; y_in < bmp.Height; y_in++)
					for(int x_in = 0; x_in < bmp.Width; x_in++){
						Color c=bmp.GetPixel(x_in,y_in);
						if(c.R <100 && c.B<100 && c.G>100)
							bmp.SetPixel(x_in,y_in,Color.GreenYellow);
			}
			pictureBox1.Image = bmp;
				
			if (String.IsNullOrEmpty(textBox2.Text))
			{
				MessageBox.Show("Ingrese un vértice válido");
				return;
			}
			int ascii = Int16.Parse(textBox2.Text);
			
			if(verticeI == null)
				auxInicial = true;
			
			
			if(auxInicial){
				verticeI = grafo.getVerticeAt(Int16.Parse(textBox2.Text));
				MessageBox.Show("Vertice inicial: " + textBox2.Text);
				auxInicial = false;
				Dijkstra(grafo,verticeI);
			}
			else{
				VerticeF = grafo.getVerticeAt(Int16.Parse(textBox2.Text));
				if(!auxInicial)
					Dijkstra(grafo,verticeI);
				
				
				
				Dijkstra2(grafo,verticeI,VerticeF);		
				Vertice valor = VerticeF;
				verticeI = valor;
								
			}
			
			if(verticeI==null){
				MessageBox.Show("Vertice no encontrado");
				return;
			}
			
			Dijk=true;
		}
		
		public void Dijkstra(Grafo grafo,Vertice verticeInicial){
			ElementoDijkstra[] VD= new ElementoDijkstra[grafo.getVerticeCount()];
			VD = inicializaVectorPesos(grafo, verticeInicial);
			int cont=0;
			while(!solucion(VD)){
				int v_d = seleccionaDefinitivo(VD);
				if(v_d == int.MaxValue){
					MessageBox.Show("Grafo NO conexo, imposible trazar recorrido");
					return;
				}
				VD = actualizaVD(VD,v_d);
				if(solucion(VD)){
					verdijkstra = new ElementoDijkstra[grafo.getVerticeCount()];
					verdijkstra = VD;
					for(int f=0;f<grafo.getVerticeCount();f++){
						dataGridView1.Rows[f].Cells[1].Value = string.Format("'{0}' --> '{1}'",verticeInicial.getdata().getId(),cont);
						dataGridView1.Rows[f].Cells[2].Value = verdijkstra[f].getpesoAcumulado().ToString();
						cont++;
					}
					/*if(Dijk==false)
						verticeI = grafo.getVerticeAt(grafo.getVerticeCount()-1);*/
				}
			}
			dataGridView1.Refresh();
		}
		
		public void Dijkstra2(Grafo grafo, Vertice verticeInicial, Vertice verticeFinal){
			int cont=0;
			int agregar;
			int[] arreglo = new int[grafo.getVerticeCount()+1];
			for(int a=0; a<grafo.getVerticeCount(); a++)
				arreglo[a] = int.MaxValue;
			int id = verticeInicial.getdata().getId();
			int idF = verticeFinal.getdata().getId();
			while(idF!=id){
				agregar = idF;
				arreglo[cont] = agregar;
				idF = verdijkstra[idF].getverticeProveniente();
				cont++;
			}
			arreglo[cont] = id;
			for(int i=cont; i>0; i--){
				Point puntoI = new Point();
				Point puntoF = new Point();
				for(int j=0; j<grafo.getVerticeCount(); j++){
					if(grafo.getVerticeAt(j).getdata().getId()==arreglo[i]){
						puntoI.X = (int)grafo.getVerticeAt(j).getdata().getx_c();
						puntoI.Y = (int)grafo.getVerticeAt(j).getdata().gety_c();
					}
					if(grafo.getVerticeAt(j).getdata().getId()==arreglo[i-1]){
						puntoF.X = (int)grafo.getVerticeAt(j).getdata().getx_c();
						puntoF.Y = (int)grafo.getVerticeAt(j).getdata().gety_c();
					}
				}
				animarParticula(ubicacion2(bmpUbicacion,puntoI,puntoF), ubicacion1(bmpUbicacion,puntoI,puntoF), bmp);
				pictureBox1.Image = bmp;
			}
		}
		
		
		public ElementoDijkstra[] inicializaVectorPesos(Grafo grafo, Vertice verticeInicial){
			ElementoDijkstra[] vector = new ElementoDijkstra[grafo.getVerticeCount()];
			for(int a=0; a<grafo.getVerticeCount(); a++){
				vector[a] = new ElementoDijkstra();
				vector[a].setpesoAcumulado(float.PositiveInfinity);
				vector[a].setverticeProveniente(int.MaxValue);
				vector[a].setDefinitivo(false);
			}
			vector[verticeInicial.getdata().getId()].setpesoAcumulado(0);
			vector[verticeInicial.getdata().getId()].setverticeProveniente(verticeInicial.getdata().getId());
			return vector;	
		}
		
		public bool solucion(ElementoDijkstra[] vd){
			for(int a=0; a<grafo.getVerticeCount(); a++){
				if(vd[a].getDefinitivo()==false)
				return false;
			}
			return true;
		}
		
		public int seleccionaDefinitivo(ElementoDijkstra[] vd){
			int indice_menor;
			try
    		{
				indice_menor = menorNoDefinitivo(vd);
				vd[indice_menor].setDefinitivo(true);
    		}
    		catch
    		{
    			return int.MaxValue;
   		    }
    		return indice_menor;
		}
		
		public int menorNoDefinitivo(ElementoDijkstra[] Vd){
			int menor=int.MaxValue;
			for(int b=0; b<grafo.getVerticeCount(); b++){
				if(Vd[b].getpesoAcumulado()<menor && Vd[b].getDefinitivo()==false)
					menor = b;
			}
			return menor;
		}
		
		public ElementoDijkstra[] actualizaVD(ElementoDijkstra[] Vd, int indice){
			float pesoActual = Vd[indice].getpesoAcumulado();
			Vertice v = grafo.getVerticeAt(indice);
			for(int i=0; i<v.getAristasContador();i++){
				Arista a_i = v.getAristaAt(i);
				if(a_i.getWeight()!=0){
				float peso = pesoActual + a_i.getWeight();
					int v_d = a_i.getDestino().getdata().getId();
					if(Vd[v_d].getpesoAcumulado() > peso){
						Vd[v_d].setpesoAcumulado(peso);
						Vd[v_d].setverticeProveniente(v.getdata().getId());
					}
				}
			}
			return Vd;
		}		
	}
}