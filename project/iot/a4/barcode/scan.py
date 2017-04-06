import io
import time
import picamera
from PIL import Image
import zbar
import signal
import post

continue_reading = True

# Capture SIGINT for cleanup when the script is aborted
def end_read(signal,frame):
    global continue_reading
    continue_reading = False

# Hook the SIGINT
signal.signal(signal.SIGINT, end_read)

# Welcome message
print "Press Ctrl-C to stop."

with picamera.PiCamera() as camera:
    while continue_reading:
        # Create the in-memory stream
        stream = io.BytesIO()
	camera.start_preview()
	time.sleep(3)
	camera.capture(stream, format='jpeg')

	# "Rewind" the stream to the beginning so we can read its content
	stream.seek(0)
	pil = Image.open(stream)

	# create a reader
	scanner = zbar.ImageScanner()

	# configure the reader
	scanner.parse_config('enable')

	pil = pil.convert('L')
	width, height = pil.size
	raw = pil.tostring()

	# wrap image data
	image = zbar.Image(width, height, 'Y800', raw)

	# scan the image for barcodes
	scanner.scan(image)

	# extract results
	for symbol in image:
            print(symbol.data)
            post.post_code(symbol.data)
		
            # clean up
            del(image)
