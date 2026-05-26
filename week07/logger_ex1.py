#Ex 5
import logging

logging.basicConfig(level=logging.INFO, format= "%(levelname)s|%(message)s")

logger = logging.getLogger(__name__)

logger.info("Applicaation started")

#Ex 6
def process_payment(user_id, amount):
    print(f'Starting payment for user {user_id}')
    if amount <= 0:
        logger.error('ERROR: Invalid amount')
        return
    if amount > 10000:
        logger.warning('WARNING: Large transaction')
        logger.info(f'Payment of {amount} completed for user {user_id}')

#Ex 7
logging.basicConfig(level=logging.INFO, filename="app.log",encoding="utf-8", format="" \
"%(asctime)s|%(levelname)s|%(name)s|%(message)s")

logger = logging.getLogger("payment")

def write_tree_simple_logs():
    logger.info("This is info")
    logger.warning("This is warning")
    logger.error("This is error")

#Ex 8

def read_config(filepath):
    logger.info("trying to open the file")
    try:
        with open(filepath) as f:
            data = f.read()
            logger.info("File opend secsesfuly")
        return data
    except FileNotFoundError:
        logger.exception("The file didnt found")
        return None

#Ex 10


#Ex 11 Not Code
#Admin - DEBUGER
#OUT SERVICE NOT RESPOND - ERROR
#tax calculation func starts - INFO
#SSL wiil be expired in 7 days - WARNING
#order canceld by costumer - INFO
#payment failed tree times - ERROR

#EX 12
import logging

logging.basicConfig(level=logging.DEBUG)

logger = logging.getLogger(__name__)

def register_user(email, password, age):
    logger.debug('register system started to work')
    if age < 18:
        logger.error('The age is bad is under the treshold')
        return
    logger.info('ok Registaration sucseed !', extra= {"email":email,"has_password":bool(password)})
    logger.info('the opearation ended')

#Ex 13
