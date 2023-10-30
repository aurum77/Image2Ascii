// using(var image = SixLabors.ImageSharp.Image.Load<SixLabors.ImageSharp.PixelFormats.Rgb24>)

using SixLabors.ImageSharp.Formats;

// 0-255, to 0-71
int Map(double value)
{
    // factor is 3,55
    return (int)Math.Round(value / 3.55d, MidpointRounding.ToZero);
}

// 71 chars to represent luminosity between 0-255
string grayscale = @"$@B%8&WM#*oahkbdpqwmZO0QLCJUYXzcvunxrjft/\|()1{}[]?-_+~<>i!lI;:,\""^`'. ";
int width;
int height;

using (Image<Rgb24> image = Image.Load<Rgb24>("./Image/lena.jpg"))
{
    width = image.Width;
    height = image.Height;

    using (Image<L8> grayscaleImage = image.CloneAs<L8>())
    {
        for (int i = 0; i < width; ++i)
        {
            for (int j = 0; j < height; ++j)
            {
                Console.Write(grayscale[Map(grayscaleImage[j, i].PackedValue)]);
            }
            Console.Write("\n");
        }
    }
}
