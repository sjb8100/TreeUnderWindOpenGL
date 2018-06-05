using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;
using OpenTK.Input;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Reflection;
using GL = OpenTK.Graphics.OpenGL.GL;

namespace Terrain {
	class Game : GameWindow {

		private Camera camera;
		private HUD hud;
		private Terrain terrain;

		public static Game Instance { 
			get { return instance == null ? (instance = new Game()) : instance; } 
		}
		private static Game instance = null;

		private Game() : base(1280, 720) {
			VSync = VSyncMode.On;
			Title = "Курсовая работа по проектированию ландшафта";

			camera = AddObject(Camera.Instance);
			terrain = AddObject(Terrain.Instance);
			hud = AddObject(HUD.Instance);

			hud.FPSWindow = 10;
			hud.Width = ClientRectangle.Width;
			hud.Height = ClientRectangle.Height;
		}

		public E AddObject<E>(E obj) {
			if (obj is ILoadable) {
				LoadObjects += () => (obj as ILoadable).Load();
			}
			if (obj is IRenderable) {
				RenderObjects += () => (obj as IRenderable).Render();
			}
			if (obj is IUpdateable) {
				UpdateObjects += () => (obj as IUpdateable).Update();
			}
			if (obj is IResizeable) {
				ResizeObjects += (width, height) => (obj as IResizeable).Resize(width, height);
			}
			return obj;
		}

		public delegate void LoadObject();
		public event LoadObject LoadObjects;
		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);
			Util.Profile("Loading", () => {
				LoadObjects();
				SetupCamera();	
			});
		}
	

		public delegate void RenderObject();
		public event RenderObject RenderObjects;
		protected override void OnRenderFrame(FrameEventArgs e) {
			base.OnRenderFrame(e);
			GL.CullFace(CullFaceMode.Back);
			GL.FrontFace(FrontFaceDirection.Ccw);
			GL.Enable(EnableCap.DepthTest);
			GL.ClearColor(Color.FromArgb(0, 0, 0));	
			GL.MatrixMode(MatrixMode.Modelview);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            var location = camera.Location;
            if (location.Y > 3000f) location.Y = 3000f;
            if (location.Y < 0) location.Y = 0;
            if (location.Z > 7000f) location.Z = 7000f;
            if (location.Z < -1000f) location.Z = -1000f;
            if (location.X > 7000f) location.X = 7000f;
            if (location.X < -1000f) location.X = -1000f;
            camera.Location = location;

            camera.LoadMatrix();
			RenderObjects();
			SwapBuffers();
		}

		public delegate void UpdateObject();
		public event UpdateObject UpdateObjects;
		protected override void OnUpdateFrame(FrameEventArgs e) {
			UpdateObjects();
			if (Keyboard[Key.Escape]) Exit();
		}

		public delegate void ResizeObject(int width, int height);
		public event ResizeObject ResizeObjects;
		protected override void OnResize(EventArgs e) {
			base.OnResize(e);
			GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);
			Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4f, Width / (float)Height, 1.0f, 60000.0f);
			GL.MatrixMode(MatrixMode.Projection);
			GL.LoadMatrix(ref projection);
			ResizeObjects(ClientRectangle.Width, ClientRectangle.Height);
		}

		public void SetupCamera() {
			var location = camera.Location;

			try {
				Vector3 center = terrain.HeightVectorAt(terrain.MapSize / 2, terrain.MapSize / 2);
				location.X = center.X-5000;
				location.Z = center.Z-3000;
                location.Y = center.Y + 900f;
            } catch (Exception e) {
				Console.WriteLine(e);
			}
			camera.Location = location;
		}

		[STAThread]
		public static void Main() {
			using (Game game = Game.Instance) {
				game.Run(60.0);
			}
		}

	}
}