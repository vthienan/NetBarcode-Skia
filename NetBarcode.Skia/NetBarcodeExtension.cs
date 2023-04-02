using SkiaSharp;

namespace NetBarcode.Skia;

public static class NetBarcodeExtension
{
    public static SKBitmap BarcodeScannerGetSkiaBitmap(this Barcode barcode)
    {
        var skDrawer = new SkBarcodeDrawer();
        var binaryRepresentation = barcode.GetBinaryRepresentation();

        if (binaryRepresentation is null)
        {
            throw new Exception("Failed to get binary string representation of the barcode");
        }

        return skDrawer.GenerateBarcodeFromBinary(binaryRepresentation, 2, 20, SKColors.Black,
            SKColors.White);
    }
}