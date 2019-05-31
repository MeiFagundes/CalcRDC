using System;

namespace CalcRDC {
    public class HardwareEstimator {

        public int TomadasFemea { get { return (2 * _ptsTele) + _ptsDados; } }
        public int Espelhos { get { return _ptsDados + _ptsTele; } }
        public int CabosMH { get { return TomadasFemea; } }
        public int EtiquetasAT { get { return TomadasFemea + Espelhos; } }
        public int EtiquetasMH { get { return CabosMH * 2; } }
        public int EtiquetasTele { get { return _ptsTele * 3; } }
        public int EtiquetasDados { get { return _ptsDados * 2; } }
        public int EtiquetasPP { get { return PatchPanels * 24; } }
        public int PatchPanels { get { return Decimal.ToInt32(Math.Ceiling((Decimal)TomadasFemea / 24)); } }
        public int Switchs { get { return PatchPanels; } }
        public int PatchCableCordDados { get { return _ptsDados; } }
        public int PatchCableCordTele { get { return _ptsTele * 2; } }
        public int PatchCableCordCFTV { get { return _ptsCFTV; } }
        public int PatchCableCordVoIP { get { return _ptsVOIP; } }
        public int OrganizadoresCabo { get { return PatchPanels * 2; } }
        public bool RackAberto { get { return _rackAberto; } }
        public int TamanhoRack { get {
                UpdateRackinfo();
                return _tamRack;
            } }
        public int QtRacks {
            get {
                UpdateRackinfo();
                return _qtRacks;
            }
        }
        public int PorcaGaiola { get {
                UpdateRackinfo();
                return 4 * TamanhoRack * QtRacks; } }
        

        readonly int _ptsDados, _ptsTele, _ptsCFTV, _ptsVOIP;
        readonly bool _rackAberto;
        int _tamRack, _qtRacks;

        public HardwareEstimator(int ptsDados, int ptsTele, int ptsCFTV, int ptsVoIP, bool rackAberto) {
            _ptsDados = ptsDados;
            _ptsTele = ptsTele;
            _ptsCFTV = ptsCFTV;
            _ptsVOIP = ptsVoIP;
            _rackAberto = rackAberto;
        }

        void UpdateRackinfo() {

            var tamTotalRack = Switchs + PatchPanels + OrganizadoresCabo + 4.0;

            if (!_rackAberto)
                tamTotalRack += 2.0;
            tamTotalRack *= 1.5;

            var qtRacks = 1;
            int tamRackTmp = (int) tamTotalRack;
            while (Math.Ceiling(tamTotalRack / qtRacks) > 48) {
                qtRacks++;
                tamRackTmp = (int) Math.Ceiling(tamTotalRack / qtRacks);
            }
            tamTotalRack = tamRackTmp;
            _qtRacks = qtRacks;

            if (tamTotalRack < 12) {
                _tamRack = (int) Math.Ceiling(tamTotalRack / 2) * 2;
            }
            else if (tamTotalRack > 12 && tamTotalRack < 48) {
                _tamRack = (int) Math.Ceiling(tamTotalRack / 4) * 4;
            }

            if (_tamRack < 1)
                _tamRack = 1;
        }
    }
}