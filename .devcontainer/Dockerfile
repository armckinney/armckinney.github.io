FROM armck/dotnet:8.0

LABEL   deployable="false" \
    description="Development container for portfolio"

ARG WORKSPACE=/workspaces/armckinneygithubio
ENV WORKSPACE=${WORKSPACE}

# make non-interactive for build
ENV DEBIAN_FRONTEND=noninteractive

RUN mkdir /tmp/container \
    && cd /tmp/container \
    # indirect installs
    && apt-get update && apt-get -y install  \
    curl \
    wget \
    build-essential \
    # azure cli keys and registry
    && curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add - \
    && echo "deb [arch=$(dpkg --print-architecture)] https://packages.microsoft.com/repos/azure-cli/ $(lsb_release -cs) main"  > /etc/apt/sources.list.d/azure-cli.list \
    # installs
    && apt-get update && apt-get -y install \
    azure-cli \
    # cleanup
    && apt-get autoremove -y \
    && apt-get clean -y \
    && rm -rf /var/lib/apt/lists/* \
    && rm -rf /tmp/container


WORKDIR ${WORKSPACE}

# restore dialog for interactive use
ENV DEBIAN_FRONTEND=dialog
