using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Java.Lang;
using AlertDialog = Android.App.AlertDialog;

namespace CalcRDC {
    [Activity(Label = "CalcRDC", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity {

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Button btnCalc = FindViewById<Button>(Resource.Id.btnCalc);
            btnCalc.Click += (sender, e) => {
                BtnCalcOnClick();
            };
        }

        public override bool OnCreateOptionsMenu(IMenu menu) {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item) {

            AlertDialog.Builder aboutAlert = new AlertDialog.Builder(this);
            aboutAlert.SetTitle("Sobre");

            aboutAlert.SetMessage("Desenvolvido por Mei Fagundes\nGNU General Public License v3.0, 2019");

            Dialog dialog = aboutAlert.Create();
            dialog.Show();

            return base.OnOptionsItemSelected(item);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults) {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        void BtnCalcOnClick() {

            EditText etPtsDados = FindViewById<EditText>(Resource.Id.ptsRede);
            EditText etPtsTele = FindViewById<EditText>(Resource.Id.ptsTele);
            EditText etPtsCFTV = FindViewById<EditText>(Resource.Id.ptsCFTV);
            EditText etPtsVoIP = FindViewById<EditText>(Resource.Id.ptsVOIP);
            RadioGroup rgRack = FindViewById<RadioGroup>(Resource.Id.tipoRack);
            RadioButton rbtTipoRack = FindViewById<RadioButton>(rgRack.CheckedRadioButtonId);

            int ptsDados = etPtsDados.Text != "" ? Integer.ParseInt(etPtsDados.Text) : 0;
            int ptsTele = etPtsTele.Text != "" ? Integer.ParseInt(etPtsTele.Text) : 0;
            int ptsCFTV = etPtsCFTV.Text != "" ? Integer.ParseInt(etPtsCFTV.Text) : 0;
            int ptsVoIP = etPtsVoIP.Text != "" ? Integer.ParseInt(etPtsVoIP.Text) : 0;

            HardwareEstimator r = new HardwareEstimator(ptsDados , ptsTele, ptsCFTV, ptsVoIP, rbtTipoRack.Text.Contains("Aberto"));
            ShowResults(r);
        }

        void ShowResults(HardwareEstimator r) {

            var resultActivity = new Intent(this, typeof(ResultActivity));

            resultActivity.PutExtra("TomadasFemea", r.TomadasFemea);
            resultActivity.PutExtra("Espelhos", r.Espelhos);
            resultActivity.PutExtra("CabosMH", r.CabosMH);
            resultActivity.PutExtra("EtiquetasAT", r.EtiquetasAT);
            resultActivity.PutExtra("EtiquetasMH", r.EtiquetasMH);
            resultActivity.PutExtra("EtiquetasTele", r.EtiquetasTele);
            resultActivity.PutExtra("EtiquetasRede", r.EtiquetasDados);
            resultActivity.PutExtra("EtiquetasPP", r.EtiquetasPP);
            resultActivity.PutExtra("PatchPanels", r.PatchPanels);
            resultActivity.PutExtra("Switchs", r.Switchs);
            resultActivity.PutExtra("PatchCableCordRede", r.PatchCableCordDados);
            resultActivity.PutExtra("PatchCableCordTele", r.PatchCableCordTele);
            resultActivity.PutExtra("PatchCableCordCFTV", r.PatchCableCordCFTV);
            resultActivity.PutExtra("PatchCableCordVOIP", r.PatchCableCordVoIP);
            resultActivity.PutExtra("OrgCabo", r.OrganizadoresCabo);
            resultActivity.PutExtra("TamRack", r.TamanhoRack);
            resultActivity.PutExtra("QtRack", r.QtRacks);
            resultActivity.PutExtra("tipo", r.RackAberto ? 1 : 0);
            resultActivity.PutExtra("PorcaGaiola", r.PorcaGaiola);

            StartActivity(resultActivity);
        }
    }
}

