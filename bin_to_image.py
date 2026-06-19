import os

filepath = r"C:\Users\alex5\Downloads\complaintimage-ImageData.bin"

data = open(filepath, "rb").read()
print(f"File size: {len(data)} bytes ({len(data)/1024:.1f} KB)")
print(f"First 4 bytes (hex): {data[:4].hex()}")

# Detect image type from magic bytes
if data[:4] == b"\x89PNG":
    ext = ".png"
elif data[:2] == b"\xff\xd8":
    ext = ".jpg"
elif data[:4] == b"GIF8":
    ext = ".gif"
elif data[:2] == b"BM":
    ext = ".bmp"
else:
    ext = ".png"
    print(f"Unknown format, defaulting to PNG")

out = f"C:/Users/alex5/Downloads/complaintimage_output{ext}"
with open(out, "wb") as f:
    f.write(data)
print(f"Done! Saved to: {out}")
