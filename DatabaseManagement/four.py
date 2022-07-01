from PIL import Image
import numpy as np

w, h = 21600, 10800
data = np.zeros((h, w, 3), dtype=np.uint8)
data[0:256, 0:256] = [255, 0, 0] # red patch in upper left
print(data.shape)
img = Image.fromarray(data, 'RGB')
img.save('four.png')
img.show()