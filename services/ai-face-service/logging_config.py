import logging
from pythonjsonlogger import jsonlogger


def setup_logging():
    logger = logging.getLogger()
    logger.setLevel(logging.INFO)

    logHandler = logging.StreamHandler()
    formatter = jsonlogger.JsonFormatter(
        '%(asctime)s %(name)s %(levelname)s %(message)s '
        '%(filename)s %(lineno)d'
    )
    logHandler.setFormatter(formatter)
    logger.addHandler(logHandler)

    # Add extra fields for all logs
    old_factory = logging.getLogRecordFactory()

    def record_factory(*args, **kwargs):
        record = old_factory(*args, **kwargs)
        record.service = "ai-face"
        record.env = "dev"
        return record

    logging.setLogRecordFactory(record_factory)
