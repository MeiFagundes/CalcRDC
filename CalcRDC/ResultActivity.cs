using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace CalcRDC {
    [Activity(Label = "Resultado", Theme = "@style/AppTheme")]
    public class ResultActivity : Activity {
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_result);

            SetResult();
        }

        private void SetResult() {

            // ATR
            var tomadasFemeaRow = FindViewById<TextView>(Resource.Id.tomadasFemeaRow);
            var espelhosRow = FindViewById<TextView>(Resource.Id.espelhosRow);
            var cordDadosRow = FindViewById<TextView>(Resource.Id.CordRedeRow);
            var cordTeleRow = FindViewById<TextView>(Resource.Id.CordTeleRow);
            var cordVoIPRow = FindViewById<TextView>(Resource.Id.CordVOIPRow);
            var cordCFTVRow = FindViewById<TextView>(Resource.Id.CordCFTVRow);
            var etiquetasATRow = FindViewById<TextView>(Resource.Id.EtiquetasATRow);

            tomadasFemeaRow.Text = Intent.GetIntExtra("TomadasFemea", 0).ToString();
            espelhosRow.Text = Intent.GetIntExtra("Espelhos", 0).ToString();
            cordTeleRow.Text = Intent.GetIntExtra("PatchCableCordTele", 0).ToString();
            cordVoIPRow.Text = Intent.GetIntExtra("PatchCableCordVOIP", 0).ToString();
            cordDadosRow.Text = Intent.GetIntExtra("PatchCableCordRede", 0).ToString();
            cordCFTVRow.Text = Intent.GetIntExtra("PatchCableCordCFTV", 0).ToString();
            etiquetasATRow.Text = Intent.GetIntExtra("EtiquetasAT", 0).ToString();

            // MH
            var cabosMHRow = FindViewById<TextView>(Resource.Id.cabosRow);
            var etiquetasMHRow = FindViewById<TextView>(Resource.Id.etiquetasMHRow);

            cabosMHRow.Text = Intent.GetIntExtra("CabosMH", 0).ToString();
            etiquetasMHRow.Text = Intent.GetIntExtra("EtiquetasMH", 0).ToString();

            // Tele
            var patchPanel = FindViewById<TextView>(Resource.Id.patchPanel);
            var swt = FindViewById<TextView>(Resource.Id.swt);
            var organizadoresCabo = FindViewById<TextView>(Resource.Id.orgCabo);
            var cableTeleRow = FindViewById<TextView>(Resource.Id.CableTeleRow);
            var cableVoipRow = FindViewById<TextView>(Resource.Id.CableVoipRow);
            var cableDadosRow = FindViewById<TextView>(Resource.Id.CableDadosRow);
            var cableCFTVRow = FindViewById<TextView>(Resource.Id.CableCFTVRow);

            patchPanel.Text = Intent.GetIntExtra("PatchPanels", 0).ToString();
            swt.Text = Intent.GetIntExtra("Switchs", 0).ToString();
            organizadoresCabo.Text = Intent.GetIntExtra("OrgCabo", 0).ToString();
            cableTeleRow.Text = Intent.GetIntExtra("PatchCableCordTele", 0).ToString();
            cableVoipRow.Text = Intent.GetIntExtra("PatchCableCordVOIP", 0).ToString();
            cableDadosRow.Text = Intent.GetIntExtra("PatchCableCordRede", 0).ToString();
            cableCFTVRow.Text = Intent.GetIntExtra("PatchCableCordCFTV", 0).ToString();

            // Rack
            var tamRack = FindViewById<TextView>(Resource.Id.tamRack);
            var qtRack = FindViewById<TextView>(Resource.Id.qtRack);
            var tipoRack = FindViewById<TextView>(Resource.Id.tipoRack);
            var exaustor = FindViewById<TextView>(Resource.Id.exaustor);

            tamRack.Text = Intent.GetIntExtra("TamRack", 0).ToString() + "U";
            qtRack.Text = Intent.GetIntExtra("QtRack", 0).ToString();
            tipoRack.Text = Intent.GetIntExtra("tipo", 0) == 1 ? "Aberto" : "Fechado";
            exaustor.Text = Intent.GetIntExtra("tipo", 0) == 1 ? "Não Inclui" : "Inclui";

            // Ext
            var porcaGaiola = FindViewById<TextView>(Resource.Id.porcaGaiola);

            porcaGaiola.Text = Intent.GetIntExtra("PorcaGaiola", 0).ToString();

        }
    }
}