using ResourceReader;
using System.Windows.Forms;

namespace DemoApp
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

			string resource = ManifestResourceReader.ReadString(ManifestResourceReader.GetResourceAssembly(), "DemoApp.THE LEGENDARY REE.ree");
			MessageBox.Show(resource, "THE LEGENDARY REE.ree", MessageBoxButtons.OK);

			Timer t = new Timer { Interval = 100 };
			t.Tick += (s, e) =>
			{
				t.Enabled = false;
				Close();
			};
			t.Start();
		}
	}
}
