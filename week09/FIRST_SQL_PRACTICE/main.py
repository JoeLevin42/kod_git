from fastapi import FastAPI
import uvicorn
import db

app = FastAPI()

@app.get("/schema")
def get_schema():

    columns = db.get_schema()

    return {"columns":columns}