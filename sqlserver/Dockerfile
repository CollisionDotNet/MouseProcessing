FROM mcr.microsoft.com/mssql/server:2022-latest

# Create app directory
USER root
RUN mkdir -p /usr/src/app
WORKDIR /usr/src/app

# Copy initialization scripts
COPY sqlserver/ /usr/src/app

HEALTHCHECK --interval=10s --timeout=3s --start-period=10s --retries=10 CMD /opt/mssql-tools18/bin/sqlcmd -U SA -P CursorDbPassword1! -C -Q "SELECT 1" -b -o /dev/null