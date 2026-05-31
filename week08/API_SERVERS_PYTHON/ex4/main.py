from fastapi import FastAPI
import uvicorn
from datetime import datetime

app = FastAPI()

@app.get("/status")
def get_date():
    return {"server_name":"poppet_serrver","datetime":datetime.now()}


if __name__ == "__main__":
    uvicorn.run(app)
