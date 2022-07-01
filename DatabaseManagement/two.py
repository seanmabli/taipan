import rasterio
import numpy as np
from PIL import Image

dataset = rasterio.open("world.tif")
window = rasterio.windows.Window(0, 0, 21600, 10800)
out = dataset.read(window=window)
out = out.reshape(10800, 21600, 3).astype(np.uint8)
print(out.shape)

img = Image.fromarray(out, "RGB")
img.save("two.png")
img.show()