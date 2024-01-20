export class TableFilterModel implements ITableFilterModel {
  filters: { [key: string]: any; } | undefined;
  first: number;
  rows: number;
  sortField: string | undefined;
  sortOrder: number;
  multiSortMeta: TableFilterSortMeta[] | undefined;

  constructor(data?: ITableFilterModel) {
      if (data) {
          for (var property in data) {
              if (data.hasOwnProperty(property))
                  (<any>this)[property] = (<any>data)[property];
          }
      }
  }

  init(_data?: any) {
      if (_data) {
          if (_data["filters"]) {
              this.filters = {} as any;
              for (let key in _data["filters"]) {
                  if (_data["filters"].hasOwnProperty(key))
                      (<any>this.filters)[key] = _data["filters"][key];
              }
          }
          this.first = _data["first"];
          this.rows = _data["rows"];
          this.sortField = _data["sortField"];
          this.sortOrder = _data["sortOrder"];
          if (Array.isArray(_data["multiSortMeta"])) {
              this.multiSortMeta = [] as any;
              for (let item of _data["multiSortMeta"])
                  this.multiSortMeta?.push(TableFilterSortMeta.fromJS(item));
          }
      }
  }

  static fromJS(data: any): TableFilterModel {
      data = typeof data === 'object' ? data : {};
      let result = new TableFilterModel();
      result.init(data);
      return result;
  }

  toJSON(data?: any) {
      data = typeof data === 'object' ? data : {};
      if (this.filters) {
          data["filters"] = {};
          for (let key in this.filters) {
              if (this.filters.hasOwnProperty(key))
                  (<any>data["filters"])[key] = (<any>this.filters)[key];
          }
      }
      data["first"] = this.first;
      data["rows"] = this.rows;
      data["sortField"] = this.sortField;
      data["sortOrder"] = this.sortOrder;
      if (Array.isArray(this.multiSortMeta)) {
          data["multiSortMeta"] = [];
          for (let item of this.multiSortMeta)
              data["multiSortMeta"].push(item.toJSON());
      }
      return data;
  }

  clone(): TableFilterModel {
      const json = this.toJSON();
      let result = new TableFilterModel();
      result.init(json);
      return result;
  }
}

export interface ITableFilterModel {
  filters: { [key: string]: any; } | undefined;
  first: number;
  rows: number;
  sortField: string | undefined;
  sortOrder: number;
  multiSortMeta: TableFilterSortMeta[] | undefined;
}

export class TableFilterSortMeta implements ITableFilterSortMeta {
  field: string | undefined;
  order: number;

  constructor(data?: ITableFilterSortMeta) {
      if (data) {
          for (var property in data) {
              if (data.hasOwnProperty(property))
                  (<any>this)[property] = (<any>data)[property];
          }
      }
  }

  init(_data?: any) {
      if (_data) {
          this.field = _data["field"];
          this.order = _data["order"];
      }
  }

  static fromJS(data: any): TableFilterSortMeta {
      data = typeof data === 'object' ? data : {};
      let result = new TableFilterSortMeta();
      result.init(data);
      return result;
  }

  toJSON(data?: any) {
      data = typeof data === 'object' ? data : {};
      data["field"] = this.field;
      data["order"] = this.order;
      return data;
  }

  clone(): TableFilterSortMeta {
      const json = this.toJSON();
      let result = new TableFilterSortMeta();
      result.init(json);
      return result;
  }
}

export interface ITableFilterSortMeta {
  field: string | undefined;
  order: number;
}
