namespace Sunshine_SmileLimitedCo
{
    internal class DetailedMaterialInfo
    {
        private string materialId;
        private string materialName;
        private string materialQty;
        private string materialUnit;

        public DetailedMaterialInfo(string materialId, string materialName, string materialQty, string materialUnit)
        {
            this.materialId = materialId;
            this.materialName = materialName;
            this.materialQty = materialQty;
            this.materialUnit = materialUnit;
        }
    }
}