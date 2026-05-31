from fastapi import FastAPI
import uvicorn

app = FastAPI()

@app.get("/calc/{a}/{op}/{b}")
def calc(a,op,b):
    result = None
    try:
        if op == "add":
            result = int(a)+int(b)
        elif op =="sub":
            result = int(a)-int(b)
        elif op == "mul":
            result = int(a)*int(b)
        elif op == "div":
            result = int(a)/int(b)
    except ZeroDivisionError as e:
        return f"Error : {e}"
    return {"opearation":op,"result":result}


if __name__ == "__main__":
    uvicorn.run(app)