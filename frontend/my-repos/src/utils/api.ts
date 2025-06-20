type RequestMethod = "GET" | "POST" | "DELETE" | "PUT" | "PATCH";

interface APIOptions {
  baseUrl: string;
  headers: Record<string, string>;
}

interface APIError {
  status: number;
  message: string;
}

export interface RepositoryResponse {
  id: string;
  name: string;
  description: string;
  language: string;
  updatedDateTime: Date;
  owner: string;
  repositoryUrl: string;
  isFavorite: boolean;
}

class API {
  private _url: string;
  private _headers: Record<string, string>;

  constructor(options: APIOptions) {
    this._url = options.baseUrl;
    this._headers = options.headers;
  }

  private async _makeRequest<T = any>(
    endpoint: string,
    method: RequestMethod = "GET",
    body: any = null
  ): Promise<T> {
    const options: RequestInit = {
      method,
      headers: this._headers,
    };

    if (body) {
      options.body = JSON.stringify(body);
    }

    const response = await fetch(`${this._url}${endpoint}`, options);

    if (response.ok) {
      if (response.status === 204) return [] as T;
      return response.json();
    }

    const error = await response.json();

    const errorData: APIError = {
      status: response.status,
      message:
        typeof error === "object" && error.message
          ? error.message
          : String(error),
    };

    return Promise.reject(errorData);
  }

  public create(repositoryUrl: string): Promise<RepositoryResponse> {
    return this._makeRequest("/repositorio", "POST", { repositoryUrl });
  }

  public myRepositories(): Promise<RepositoryResponse[]> {
    return this._makeRequest("/repositorio/meus", "GET");
  }

  public myFavorites(): Promise<RepositoryResponse[]> {
    return this._makeRequest("/repositorio/favoritos", "GET");
  }
}

const API_URL = import.meta.env.VITE_API_URL;

const api = new API({
  baseUrl: API_URL,
  headers: { "Content-Type": "application/json" },
});

export default api;
