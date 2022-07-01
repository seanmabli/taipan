import rasterio
import numpy as np
from PIL import Image as im

dataset = rasterio.open("world.tif")

out = np.zeros((3, 400, 400))
for i in range(400):
  for j in range(400):
    window = rasterio.windows.Window(i, j, 1, 1)
    clip = dataset.read(window=window)
    out[:, i, j] = np.array(clip[:, 0, 0])

imageout = im.fromarray(out)
imageout.save('test.png')