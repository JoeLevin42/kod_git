#Log exersise 12

import logging

logger = logging.getLogger(__name__)
# logger.setLevel(logging.INFO)

console_heandler = logging.StreamHandler()
file_handler = logging.FileHandler(filename="app.log",mode="a",encoding="utf-8")
formatter = logging.Formatter("%(asctime)s|%(levelname)s|%(name)s|%(message)s")

logger.addHandler(console_heandler)
logger.addHandler(file_handler)

console_heandler.setFormatter(formatter)
file_handler.setFormatter(formatter)

logger.warning("BE careful!")