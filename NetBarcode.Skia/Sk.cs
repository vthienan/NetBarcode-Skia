using SkiaSharp;

namespace NetBarcode.Skia;

internal class SkBarcodeDrawer
{
    public SKBitmap GenerateBarcodeFromBinary(
        string binaryCode,
        int barWidth,
        int barHeight,
        SKColor barColor,
        SKColor backgroundColor)
    {
        var bitmap = new SKBitmap(barWidth * binaryCode.Length, barHeight);
        using SKCanvas canvas = new SKCanvas(bitmap);
        canvas.Clear(backgroundColor);

        var barPaint = new SKPaint
        {
            Color = barColor,
            IsAntialias = true,
            FilterQuality = SKFilterQuality.High,
        };

        SKPath barPath = new SKPath();

        for (int i = 0; i < binaryCode.Length; i++)
        {
            var bit = binaryCode[i];

            float x = i * barWidth;
            float y = 0;

            if (bit is '1')
            {
                barPath.Reset();
                barPath.MoveTo(x, y);
                barPath.LineTo(x + barWidth, y);
                barPath.LineTo(x + barWidth, y + barHeight);
                barPath.LineTo(x, y + barHeight);
                    
                canvas.DrawPath(barPath, barPaint);
            }
        }
        
        return bitmap;
    }

}
