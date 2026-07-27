import pandas as pd

df = pd.read_csv("tracks.csv")

print(df["speed"])
print(df[["id","speed"]])
print(["speed"].mean())
print(["speed"].max())