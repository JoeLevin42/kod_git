from fastapi import FastAPI , HTTPException
from pydantic import BaseModel
import setup

app = FastAPI()

class SoldierIN(BaseModel):
    name: str
    ranki: str | None = None
    unit: str | None = None

@app.get("/soldiers")
def get_list_soldiers():
    return {"soldiers":setup.get_all()}

@app.get("/soldiers/{soldiers_id}")
def get_by_id(soldier_id:int):
    the_soldier = setup.get_by_id(soldier_id)

    if the_soldier is None:
        raise HTTPException(status_code=404, detail="The soldier id not exist in the system")
    return the_soldier


@app.post("/soldiers",status_code=201)
def add_soldier(body: SoldierIN):

    setup.insert_data_to_table(body.name,body.ranki,body.unit)

    return {"message":"The soldier successfully created!"}
