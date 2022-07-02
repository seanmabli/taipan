from PIL import Image
import numpy as np
from firebase_admin import credentials, initialize_app, storage
import os

cred = credentials.Certificate("admin.json")
initialize_app(cred, {'storageBucket': 'taipan-354222.appspot.com'})

Image.MAX_IMAGE_PIXELS = 233280000
png = Image.open('world.png').convert('RGB')
png = np.array(png)

for i in range(int(png.shape[0] / 400)):
  for j in range(int(png.shape[1] / 400)):
    out = png[i*400:(i+1)*400, j*400:(j+1)*400, :]
    img = Image.fromarray(out, "RGB")
    filename = str(i).rjust(2, '0') + "-" + str(j).rjust(2, '0') + ".png"
    img.save(filename)

    bucket = storage.bucket()
    blob = bucket.blob(filename)
    blob.upload_from_filename(filename)

    blob.make_public()

    os.remove(filename)