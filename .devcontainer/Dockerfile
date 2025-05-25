FROM armck/dotnet:8.0

# set workspace directory
ARG WORKSPACE=/workspaces/portfolio
ENV WORKSPACE=${WORKSPACE}

# avoid warnings by switching to noninteractive
ENV DEBIAN_FRONTEND=noninteractive

# uses tmp install directory to keep from caching install downloads

RUN mkdir /tmp/container \
    && cd /tmp/container \
    # supporting installs
    && apt-get update && apt-get -y install  \
        curl \
    # azure cli keys and registry
    && curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add - \
    && echo "deb [arch=$(dpkg --print-architecture)] https://packages.microsoft.com/repos/azure-cli/ $(lsb_release -cs) main"  > /etc/apt/sources.list.d/azure-cli.list \
    # primary installs
    && apt-get update && apt-get -y install \
        azure-cli \
    # cleanup
    && apt-get autoremove -y \
    && apt-get clean -y \
    && rm -rf /var/lib/apt/lists/* \
    && rm -rf /tmp/container

WORKDIR ${WORKSPACE}

# switch back to dialog for any ad-hoc use of apt-get
ENV DEBIAN_FRONTEND=dialog
