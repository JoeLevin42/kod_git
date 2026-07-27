import pandas as pd

data = [412,95,250,510]

pd.Series(data, index= ["T1","T2","T3","T4"])

data1 = {
    "id" : [1,2,3],
    "speed": [412,95,250],
    "heading": [90,180,270]
}

df = pd.DataFrame(data1)






