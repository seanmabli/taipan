import rasterio
import numpy as np
from PIL import Image
Image.MAX_IMAGE_PIXELS = 2332800000

dataset = rasterio.open("world.tif")
window = rasterio.windows.Window(0, 0, 21600, 10800)
tif = dataset.read(window=window)
tif = tif.reshape(10800, 21600, 3).astype(np.uint8)

png = Image.open('world.png')
png.show()
png = np.array(png)

print(tif.shape)
print(png.shape)
print(png[0, 0])